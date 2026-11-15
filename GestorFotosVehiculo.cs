using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using TallerAutomotriz.Models;
using TallerAutomotriz.Repositorios;

namespace TallerAutomotriz
{
    public static class GestorFotosVehiculo
    {
        private static readonly Dictionary<string, Image> _cacheMiniaturas = new(StringComparer.OrdinalIgnoreCase);
        private static readonly Dictionary<string, string> _fotosPorPlaca = new(StringComparer.OrdinalIgnoreCase);
        private static readonly HashSet<IntPtr> _formulariosProcesados = new();
        private static bool _inicializado = false;
        private static bool _arreglosGlobalesActivos = false;

        public static string CarpetaFotos
        {
            get
            {
                string baseDir = AppDomain.CurrentDomain.BaseDirectory;
                DirectoryInfo? dir = new DirectoryInfo(baseDir);
                while (dir != null && !File.Exists(Path.Combine(dir.FullName, "Program.cs")))
                {
                    dir = dir.Parent;
                }

                string raiz = dir?.FullName ?? baseDir;
                string ruta = Path.Combine(raiz, "Datos", "FotosVehiculos");
                Directory.CreateDirectory(ruta);
                return ruta;
            }
        }

        private static string ArchivoRegistroFotos => Path.Combine(CarpetaFotos, "registro_fotos.csv");

        public static void ActivarArreglosGlobales()
        {
            Inicializar();
            if (_arreglosGlobalesActivos) return;
            _arreglosGlobalesActivos = true;

            Application.Idle += (s, e) =>
            {
                foreach (Form form in Application.OpenForms)
                {
                    ProcesarControlYSubcontroles(form);
                }
            };
        }

        private static void ProcesarControlYSubcontroles(Control raiz)
        {
            if (raiz is Form f && !_formulariosProcesados.Contains(f.Handle))
            {
                _formulariosProcesados.Add(f.Handle);

                if (f.GetType().Name.Equals("FrmNuevoVehiculo", StringComparison.OrdinalIgnoreCase))
                {
                    ConectarNuevoVehiculoAutomatico(f);
                }

                if (f.GetType().Name.Equals("FrmNuevaOrden", StringComparison.OrdinalIgnoreCase) ||
                    f.Text.Contains("Nueva Orden", StringComparison.OrdinalIgnoreCase))
                {
                    CorregirDisenoNuevaOrden(f);
                }
            }

            foreach (Control hijo in raiz.Controls)
            {
                if (hijo is DataGridView dgv)
                {
                    if (dgv.SelectionMode != DataGridViewSelectionMode.FullRowSelect)
                        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                    dgv.MultiSelect = false;
                    dgv.AllowUserToAddRows = false;

                    dgv.CellClick -= ForzarSeleccionFila;
                    dgv.CellClick += ForzarSeleccionFila;
                }

                if (hijo.HasChildren)
                {
                    ProcesarControlYSubcontroles(hijo);
                }
            }
        }

        private static void ForzarSeleccionFila(object? sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dgv && e.RowIndex >= 0 && e.RowIndex < dgv.Rows.Count)
            {
                dgv.Rows[e.RowIndex].Selected = true;
            }
        }

        // Ordena limpiamente los campos de "Nueva Orden" para que Descripción y Mecánico no se encimen
        private static void CorregirDisenoNuevaOrden(Form f)
        {
            void AplicarOrden()
            {
                var controles = f.Controls.Cast<Control>().ToList();

                Label? BuscarLabel(string texto) => controles.OfType<Label>()
                    .FirstOrDefault(l => l.Text.Contains(texto, StringComparison.OrdinalIgnoreCase));

                var lblPlaca = BuscarLabel("Placa");
                var lblDui = BuscarLabel("DUI");
                var lblTipo = BuscarLabel("Servicio");
                var lblCosto = BuscarLabel("Costo");
                var lblDesc = BuscarLabel("Descrip");
                var lblMec = BuscarLabel("Mec");

                var mskDui = controles.OfType<MaskedTextBox>().FirstOrDefault();

                var txtDesc = controles.OfType<TextBoxBase>()
                    .FirstOrDefault(c => c != mskDui &&
                        (c.Name.Contains("Desc", StringComparison.OrdinalIgnoreCase) ||
                         c.Name.Contains("Prob", StringComparison.OrdinalIgnoreCase) ||
                         (c is TextBox tb && tb.Multiline)));

                var txtPlaca = controles.OfType<TextBox>()
                    .FirstOrDefault(c => c != txtDesc && c.Name.Contains("Placa", StringComparison.OrdinalIgnoreCase));

                var txtCosto = controles.OfType<TextBox>()
                    .FirstOrDefault(c => c != txtDesc && c != txtPlaca);

                var cmbMec = controles.OfType<ComboBox>()
                    .FirstOrDefault(c => c.Name.Contains("Mec", StringComparison.OrdinalIgnoreCase) || c.Width > 220);

                var cmbTipo = controles.OfType<ComboBox>()
                    .FirstOrDefault(c => c != cmbMec);

                var btnGuardar = controles.OfType<Button>()
                    .FirstOrDefault(b => b.Text.Contains("Guardar", StringComparison.OrdinalIgnoreCase));

                var btnCancelar = controles.OfType<Button>()
                    .FirstOrDefault(b => b != btnGuardar && b.Text.Contains("Cancelar", StringComparison.OrdinalIgnoreCase));

                // Ocultar el logo central grande si está tapando los controles del formulario
                foreach (var pic in controles.OfType<PictureBox>())
                {
                    if (pic.Top > 110 || pic.Width > 120)
                    {
                        pic.SendToBack();
                        pic.Visible = false;
                    }
                }

                f.ClientSize = new Size(720, 520);

                // Fila 1: Placa y DUI
                if (lblPlaca != null) lblPlaca.Location = new Point(65, 138);
                if (txtPlaca != null) { txtPlaca.Location = new Point(255, 135); txtPlaca.Size = new Size(165, 28); }

                if (lblDui != null) lblDui.Location = new Point(445, 138);
                if (mskDui != null) { mskDui.Location = new Point(500, 135); mskDui.Size = new Size(155, 28); }

                // Fila 2: Tipo de Servicio y Costo Estimado
                if (lblTipo != null) lblTipo.Location = new Point(65, 193);
                if (cmbTipo != null) { cmbTipo.Location = new Point(255, 190); cmbTipo.Size = new Size(165, 28); }

                if (lblCosto != null) lblCosto.Location = new Point(445, 193);
                if (txtCosto != null) { txtCosto.Location = new Point(575, 190); txtCosto.Size = new Size(80, 28); }

                // Fila 3: Mecánico (separado arriba de la descripción para que nunca se tapen)
                if (lblMec != null) lblMec.Location = new Point(65, 248);
                if (cmbMec != null) { cmbMec.Location = new Point(255, 245); cmbMec.Size = new Size(400, 28); }

                // Fila 4: Descripción del Problema (caja blanca limpia y amplia)
                if (lblDesc != null) lblDesc.Location = new Point(65, 303);
                if (txtDesc is TextBox tb)
                {
                    tb.Multiline = true;
                    tb.Location = new Point(255, 300);
                    tb.Size = new Size(400, 95);
                    tb.BackColor = Color.White;
                    tb.ForeColor = Color.Black;
                    tb.BorderStyle = BorderStyle.FixedSingle;
                    tb.ScrollBars = ScrollBars.Vertical;
                    tb.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
                    tb.BringToFront();
                }

                // Fila 5: Botones Guardar y Cancelar
                if (btnGuardar != null) { btnGuardar.Location = new Point(255, 425); btnGuardar.Size = new Size(125, 38); }
                if (btnCancelar != null) { btnCancelar.Location = new Point(405, 425); btnCancelar.Size = new Size(125, 38); }
            }

            if (f.IsHandleCreated)
                AplicarOrden();
            else
                f.Load += (s, e) => AplicarOrden();
        }

        // Abre una ventana al hacer 1 clic sobre la foto para ver el auto en grande y descargar su imagen
        public static bool MostrarVisorFotoVehiculo(Form padre, Vehiculo vehiculo)
        {
            Inicializar();
            bool huboCambio = false;
            string nombreArchivoActual = ObtenerNombreFotoParaVehiculo(vehiculo);

            using var visor = new Form
            {
                Text = $"Fotografía del Vehículo - Placa {vehiculo.Placa}",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(560, 470),
                Font = new Font("Segoe UI", 9.5F)
            };

            string nombreCliente = vehiculo.Cliente?.Nombre ?? "(sin cliente)";

            var lblInfo = new Label
            {
                Text = $"Cliente: {nombreCliente}\n" +
                       $"Vehículo: {vehiculo.Marca} {vehiculo.Modelo} ({vehiculo.Anio})   |   Placa: {vehiculo.Placa}   |   Color: {vehiculo.Color}",
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = Color.White,
                Location = new Point(25, 15),
                Size = new Size(510, 48)
            };

            var picGrande = new PictureBox
            {
                Location = new Point(25, 70),
                Size = new Size(510, 320),
                SizeMode = PictureBoxSizeMode.Zoom,
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Image = CargarImagenCompleta(nombreArchivoActual)
            };

            var btnDescargar = new Button
            {
                Text = "Descargar imagen...",
                Location = new Point(25, 410),
                Size = new Size(165, 38),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnDescargar.FlatAppearance.BorderSize = 0;

            btnDescargar.Click += (s, e) =>
            {
                string rutaActual = Path.IsPathRooted(nombreArchivoActual)
                    ? nombreArchivoActual
                    : Path.Combine(CarpetaFotos, nombreArchivoActual);

                string ext = Path.GetExtension(rutaActual);
                if (string.IsNullOrWhiteSpace(ext)) ext = ".png";

                using var sfd = new SaveFileDialog
                {
                    Title = "Guardar fotografía del vehículo",
                    FileName = $"Vehiculo_{vehiculo.Placa}_{vehiculo.Marca}_{vehiculo.Modelo}{ext}",
                    Filter = "Imagen PNG (*.png)|*.png|Imagen JPEG (*.jpg)|*.jpg|Todos los archivos (*.*)|*.*"
                };

                if (sfd.ShowDialog(visor) == DialogResult.OK)
                {
                    try
                    {
                        if (File.Exists(rutaActual))
                            File.Copy(rutaActual, sfd.FileName, true);
                        else
                            picGrande.Image?.Save(sfd.FileName);

                        MessageBox.Show("La imagen se guardó correctamente en tu equipo.", "Imagen descargada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"No se pudo guardar la imagen: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            };

            var btnCambiar = new Button
            {
                Text = "Cambiar foto...",
                Location = new Point(205, 410),
                Size = new Size(155, 38),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(230, 126, 34),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnCambiar.FlatAppearance.BorderSize = 0;

            btnCambiar.Click += (s, e) =>
            {
                using var ofd = new OpenFileDialog
                {
                    Title = $"Seleccionar nueva fotografía para {vehiculo.Placa}",
                    Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
                };

                if (ofd.ShowDialog(visor) == DialogResult.OK)
                {
                    nombreArchivoActual = GuardarFotoDesdeArchivo(ofd.FileName);
                    AsignarFotoAPlaca(vehiculo.Placa, nombreArchivoActual);
                    picGrande.Image?.Dispose();
                    picGrande.Image = CargarImagenCompleta(nombreArchivoActual);
                    huboCambio = true;
                }
            };

            var btnCerrar = new Button
            {
                Text = "Cerrar",
                Location = new Point(425, 410),
                Size = new Size(110, 38),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(60, 60, 65),
                ForeColor = Color.White,
                DialogResult = DialogResult.OK,
                Cursor = Cursors.Hand
            };
            btnCerrar.FlatAppearance.BorderSize = 0;

            visor.Controls.AddRange(new Control[] { lblInfo, picGrande, btnDescargar, btnCambiar, btnCerrar });
            visor.ShowDialog(padre);

            picGrande.Image?.Dispose();
            return huboCambio;
        }

        private static void ConectarNuevoVehiculoAutomatico(Form modalVehiculo)
        {
            if (modalVehiculo.Tag?.ToString() == "FotoConectada") return;
            modalVehiculo.Tag = "FotoConectada";

            var placasAntes = ContextoDatos.Vehiculos.ObtenerTodos()
                .Select(v => v.Placa)
                .ToHashSet(StringComparer.OrdinalIgnoreCase);

            string fotoElegida = "auto_reciente_azul.png";
            InsistirSelectorEnModal(modalVehiculo, foto => fotoElegida = foto, null);

            modalVehiculo.FormClosed += (s, e) =>
            {
                if (modalVehiculo.DialogResult == DialogResult.OK)
                {
                    var todos = ContextoDatos.Vehiculos.ObtenerTodos();
                    var nuevo = todos.FirstOrDefault(v => !placasAntes.Contains(v.Placa)) ?? todos.LastOrDefault();
                    if (nuevo != null)
                    {
                        AsignarFotoAPlaca(nuevo.Placa, fotoElegida);
                    }
                }
            };
        }

        public static void Inicializar()
        {
            if (_inicializado) return;
            _inicializado = true;

            CrearImagenAutoSiNoExiste("auto_reciente_azul.png", Color.FromArgb(0, 122, 204), "Sedán Reciente", true);
            CrearImagenAutoSiNoExiste("auto_reciente_rojo.png", Color.FromArgb(210, 50, 65), "SUV Reciente", true);
            CrearImagenAutoSiNoExiste("auto_viejito_verde.png", Color.FromArgb(75, 115, 65), "Clásico 90s", false);
            CrearImagenAutoSiNoExiste("auto_viejito_ocre.png", Color.FromArgb(175, 115, 45), "PickUp Antiguo", false);

            if (File.Exists(ArchivoRegistroFotos))
            {
                foreach (string linea in File.ReadAllLines(ArchivoRegistroFotos))
                {
                    string[] partes = linea.Split('|');
                    if (partes.Length == 2 && !string.IsNullOrWhiteSpace(partes[0]))
                    {
                        _fotosPorPlaca[partes[0].Trim()] = partes[1].Trim();
                    }
                }
            }
        }

        public static string GuardarFotoDesdeArchivo(string rutaOrigen)
        {
            Inicializar();
            string ext = Path.GetExtension(rutaOrigen);
            string nombreArchivo = $"auto_{Guid.NewGuid():N}{ext}";
            string rutaDestino = Path.Combine(CarpetaFotos, nombreArchivo);

            File.Copy(rutaOrigen, rutaDestino, true);
            return nombreArchivo;
        }

        public static void AsignarFotoAPlaca(string? placa, string? nombreArchivoFoto)
        {
            Inicializar();
            if (string.IsNullOrWhiteSpace(placa) || string.IsNullOrWhiteSpace(nombreArchivoFoto))
                return;

            string placaLimpia = placa.Trim().ToUpperInvariant();
            _fotosPorPlaca[placaLimpia] = nombreArchivoFoto;
            _cacheMiniaturas.Remove(placaLimpia);

            GuardarRegistroEnDisco();
        }

        public static void EliminarFotoDePlaca(string? placa)
        {
            Inicializar();
            if (string.IsNullOrWhiteSpace(placa)) return;

            string placaLimpia = placa.Trim().ToUpperInvariant();
            if (_fotosPorPlaca.Remove(placaLimpia))
            {
                GuardarRegistroEnDisco();
            }
        }

        private static void GuardarRegistroEnDisco()
        {
            var lineas = _fotosPorPlaca.Select(kvp => $"{kvp.Key}|{kvp.Value}").ToList();
            File.WriteAllLines(ArchivoRegistroFotos, lineas);
        }

        public static string ObtenerNombreFotoParaVehiculo(Vehiculo v)
        {
            Inicializar();
            string placa = v.Placa?.Trim().ToUpperInvariant() ?? "";

            if (!string.IsNullOrEmpty(placa) && _fotosPorPlaca.TryGetValue(placa, out string? fotoGuardada))
            {
                string rutaCompleta = Path.Combine(CarpetaFotos, fotoGuardada);
                if (File.Exists(rutaCompleta))
                    return fotoGuardada;
            }

            bool esReciente = v.Anio >= 2015;
            int variante = Math.Abs(placa.GetHashCode()) % 2;

            if (esReciente)
                return variante == 0 ? "auto_reciente_azul.png" : "auto_reciente_rojo.png";
            else
                return variante == 0 ? "auto_viejito_verde.png" : "auto_viejito_ocre.png";
        }

        public static Image CargarImagenCompleta(string nombreArchivo)
        {
            Inicializar();
            string ruta = Path.IsPathRooted(nombreArchivo)
                ? nombreArchivo
                : Path.Combine(CarpetaFotos, nombreArchivo);

            if (!File.Exists(ruta))
                ruta = Path.Combine(CarpetaFotos, "auto_reciente_azul.png");

            byte[] bytes = File.ReadAllBytes(ruta);
            using var ms = new MemoryStream(bytes);
            return new Bitmap(ms);
        }

        public static Image ObtenerMiniaturaVehiculo(Vehiculo v, int ancho = 90, int alto = 54)
        {
            Inicializar();
            string placa = v.Placa?.Trim().ToUpperInvariant() ?? "";
            string nombreFoto = ObtenerNombreFotoParaVehiculo(v);
            string claveCache = $"{placa}_{nombreFoto}";

            if (_cacheMiniaturas.TryGetValue(claveCache, out Image? miniaturaCache))
                return miniaturaCache;

            using Image original = CargarImagenCompleta(nombreFoto);
            var bmp = new Bitmap(ancho, alto);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.Clear(Color.White);
                g.DrawImage(original, 0, 0, ancho, alto);
            }

            _cacheMiniaturas[claveCache] = bmp;
            return bmp;
        }

        public static void ConfigurarColumnaFoto(DataGridView dgv)
        {
            ActivarArreglosGlobales();
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.RowTemplate.Height = 58;

            if (!dgv.Columns.Contains("colFotoVehiculo"))
            {
                var colFoto = new DataGridViewImageColumn
                {
                    Name = "colFotoVehiculo",
                    HeaderText = "Fotografía (Clic para ver)",
                    ImageLayout = DataGridViewImageCellLayout.Zoom,
                    Width = 115,
                    ToolTipText = "Haz clic para ver en grande o descargar la imagen"
                };
                colFoto.DefaultCellStyle.NullValue = null;
                dgv.Columns.Add(colFoto);
            }
        }

        public static void EliminarVehiculoDeRepositorio(Vehiculo vehiculo)
        {
            object repo = ContextoDatos.Vehiculos;
            Type tipoRepo = repo.GetType();

            try
            {
                MethodInfo? metodoPorObjeto = tipoRepo.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault(m =>
                        (m.Name.Equals("Eliminar", StringComparison.OrdinalIgnoreCase) ||
                         m.Name.Equals("Remover", StringComparison.OrdinalIgnoreCase) ||
                         m.Name.Equals("Borrar", StringComparison.OrdinalIgnoreCase)) &&
                        m.GetParameters().Length == 1 &&
                        m.GetParameters()[0].ParameterType.IsAssignableFrom(typeof(Vehiculo)));

                if (metodoPorObjeto != null)
                {
                    metodoPorObjeto.Invoke(repo, new object[] { vehiculo });
                    EliminarFotoDePlaca(vehiculo.Placa);
                    return;
                }

                MethodInfo? metodoPorPlaca = tipoRepo.GetMethods(BindingFlags.Public | BindingFlags.Instance)
                    .FirstOrDefault(m =>
                        (m.Name.Contains("Eliminar", StringComparison.OrdinalIgnoreCase) ||
                         m.Name.Contains("Remover", StringComparison.OrdinalIgnoreCase)) &&
                        m.GetParameters().Length == 1 &&
                        m.GetParameters()[0].ParameterType == typeof(string));

                if (metodoPorPlaca != null)
                {
                    metodoPorPlaca.Invoke(repo, new object[] { vehiculo.Placa });
                    EliminarFotoDePlaca(vehiculo.Placa);
                    return;
                }

                FieldInfo? campoLista = tipoRepo.GetFields(BindingFlags.NonPublic | BindingFlags.Instance)
                    .FirstOrDefault(f => typeof(IList).IsAssignableFrom(f.FieldType));

                if (campoLista?.GetValue(repo) is IList listaInterna)
                {
                    listaInterna.Remove(vehiculo);
                    PersistirRepositorioVehiculos(repo);
                    EliminarFotoDePlaca(vehiculo.Placa);
                }
            }
            catch (TargetInvocationException ex)
            {
                throw ex.InnerException ?? ex;
            }
        }

        private static void PersistirRepositorioVehiculos(object repo)
        {
            MethodInfo? metodoGuardar = repo.GetType()
                .GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .FirstOrDefault(m => m.Name.Contains("Guardar", StringComparison.OrdinalIgnoreCase) && m.GetParameters().Length == 0);

            metodoGuardar?.Invoke(repo, null);
        }

        public static bool EditarVehiculoConModal(Form padre, Vehiculo vehiculo)
        {
            string placaAnterior = vehiculo.Placa;
            string fotoSeleccionada = ObtenerNombreFotoParaVehiculo(vehiculo);

            ConstructorInfo? ctorEditar = typeof(FrmNuevoVehiculo).GetConstructor(new[] { typeof(Vehiculo) });
            if (ctorEditar != null)
            {
                using Form modal = (Form)ctorEditar.Invoke(new object[] { vehiculo });
                modal.Tag = "FotoConectada";
                PrepararModalNuevoVehiculo(modal, foto => fotoSeleccionada = foto, fotoSeleccionada);

                if (modal.ShowDialog(padre) == DialogResult.OK)
                {
                    if (!string.Equals(placaAnterior, vehiculo.Placa, StringComparison.OrdinalIgnoreCase))
                        EliminarFotoDePlaca(placaAnterior);

                    AsignarFotoAPlaca(vehiculo.Placa, fotoSeleccionada);
                    return true;
                }
                return false;
            }

            return MostrarDialogoEdicionDirecta(padre, vehiculo);
        }

        private static bool MostrarDialogoEdicionDirecta(Form padre, Vehiculo vehiculo)
        {
            string placaOriginal = vehiculo.Placa;
            string fotoElegida = ObtenerNombreFotoParaVehiculo(vehiculo);

            using var form = new Form
            {
                Text = "Editar Vehículo",
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterParent,
                MaximizeBox = false,
                MinimizeBox = false,
                ClientSize = new Size(620, 390),
                Font = new Font("Segoe UI", 9.5F)
            };

            var lblTitulo = new Label
            {
                Text = "Editar Vehículo",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.White,
                AutoSize = true,
                Location = new Point(25, 18)
            };

            Label CrearLabel(string texto, int y) => new Label
            {
                Text = texto,
                AutoSize = true,
                ForeColor = Color.White,
                Location = new Point(25, y)
            };

            var txtPlaca = new TextBox { Location = new Point(125, 65), Size = new Size(200, 27), Text = vehiculo.Placa };
            var cmbMarca = new ComboBox { Location = new Point(125, 105), Size = new Size(200, 27), DropDownStyle = ComboBoxStyle.DropDownList };
            cmbMarca.DataSource = Enum.GetValues<MarcaVehiculo>();
            cmbMarca.SelectedItem = vehiculo.Marca;

            var txtModelo = new TextBox { Location = new Point(125, 145), Size = new Size(200, 27), Text = vehiculo.Modelo };
            var txtAnio = new TextBox { Location = new Point(125, 185), Size = new Size(200, 27), Text = vehiculo.Anio.ToString() };
            var txtColor = new TextBox { Location = new Point(125, 225), Size = new Size(200, 27), Text = vehiculo.Color };

            var cmbCliente = new ComboBox { Location = new Point(125, 265), Size = new Size(200, 27), DropDownStyle = ComboBoxStyle.DropDownList };
            var listaClientes = ObtenerListaClientesDisponibles();
            cmbCliente.DataSource = listaClientes;
            cmbCliente.DisplayMember = "Nombre";
            if (vehiculo.Cliente != null)
                cmbCliente.SelectedItem = vehiculo.Cliente;

            var btnGuardar = new Button
            {
                Text = "Guardar",
                Location = new Point(125, 325),
                Size = new Size(105, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(0, 122, 204),
                ForeColor = Color.White,
                Cursor = Cursors.Hand
            };
            btnGuardar.FlatAppearance.BorderSize = 0;

            var btnCancelar = new Button
            {
                Text = "Cancelar",
                Location = new Point(245, 325),
                Size = new Size(105, 36),
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                DialogResult = DialogResult.Cancel,
                Cursor = Cursors.Hand
            };
            btnCancelar.FlatAppearance.BorderSize = 0;

            btnGuardar.Click += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(txtPlaca.Text) || string.IsNullOrWhiteSpace(txtModelo.Text))
                {
                    MessageBox.Show("Complete la placa y el modelo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!int.TryParse(txtAnio.Text.Trim(), out int nuevoAnio) || nuevoAnio < 1900 || nuevoAnio > DateTime.Now.Year + 1)
                {
                    MessageBox.Show("Ingrese un año válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                try
                {
                    AsignarPropiedad(vehiculo, "Placa", txtPlaca.Text.Trim().ToUpperInvariant());
                    if (cmbMarca.SelectedItem is MarcaVehiculo m)
                        AsignarPropiedad(vehiculo, "Marca", m);
                    AsignarPropiedad(vehiculo, "Modelo", txtModelo.Text.Trim());
                    AsignarPropiedad(vehiculo, "Anio", nuevoAnio);
                    AsignarPropiedad(vehiculo, "Color", txtColor.Text.Trim());
                    if (cmbCliente.SelectedItem != null)
                        AsignarPropiedad(vehiculo, "Cliente", cmbCliente.SelectedItem);

                    PersistirRepositorioVehiculos(ContextoDatos.Vehiculos);

                    if (!string.Equals(placaOriginal, vehiculo.Placa, StringComparison.OrdinalIgnoreCase))
                        EliminarFotoDePlaca(placaOriginal);

                    AsignarFotoAPlaca(vehiculo.Placa, fotoElegida);
                    form.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al actualizar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            form.Controls.AddRange(new Control[]
            {
                lblTitulo,
                CrearLabel("Placa:", 68), txtPlaca,
                CrearLabel("Marca:", 108), cmbMarca,
                CrearLabel("Modelo:", 148), txtModelo,
                CrearLabel("Año:", 188), txtAnio,
                CrearLabel("Color:", 228), txtColor,
                CrearLabel("Cliente:", 268), cmbCliente,
                btnGuardar, btnCancelar
            });

            InsistirSelectorEnModal(form, foto => fotoElegida = foto, fotoElegida);

            return form.ShowDialog(padre) == DialogResult.OK;
        }

        private static List<object> ObtenerListaClientesDisponibles()
        {
            var resultado = new List<object>();
            PropertyInfo? propClientes = typeof(ContextoDatos).GetProperty("Clientes", BindingFlags.Public | BindingFlags.Static);
            object? repoClientes = propClientes?.GetValue(null);
            if (repoClientes != null)
            {
                MethodInfo? metodoTodos = repoClientes.GetType().GetMethod("ObtenerTodos");
                if (metodoTodos?.Invoke(repoClientes, null) is IEnumerable enumerable)
                {
                    foreach (object item in enumerable)
                        resultado.Add(item);
                }
            }
            return resultado;
        }

        private static void AsignarPropiedad(object destino, string nombrePropiedad, object? valor)
        {
            PropertyInfo? prop = destino.GetType().GetProperty(nombrePropiedad, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
            {
                prop.SetValue(destino, valor);
                return;
            }

            FieldInfo? backingField = destino.GetType().GetField($"<{nombrePropiedad}>k__BackingField", BindingFlags.NonPublic | BindingFlags.Instance);
            backingField?.SetValue(destino, valor);
        }

        public static void PrepararModalNuevoVehiculo(Form modal, Action<string> alCambiarFoto, string? fotoInicialParam = null)
        {
            modal.Tag = "FotoConectada";
            InsistirSelectorEnModal(modal, alCambiarFoto, fotoInicialParam);
        }

        private static void InsistirSelectorEnModal(Form modal, Action<string> alCambiarFoto, string? fotoInicialParam)
        {
            Inicializar();
            string fotoInicial = string.IsNullOrWhiteSpace(fotoInicialParam) ? "auto_reciente_azul.png" : fotoInicialParam;
            alCambiarFoto(fotoInicial);

            void AgregarGrupo()
            {
                if (modal.Controls.ContainsKey("grpFotoVehiculo")) return;

                foreach (Control c in modal.Controls)
                {
                    c.Anchor &= ~AnchorStyles.Right;
                }

                var camposEntrada = modal.Controls.OfType<Control>()
                    .Where(c => c is TextBox || c is ComboBox || c is NumericUpDown)
                    .ToList();

                int bordeDerechoCampos = camposEntrada.Any() ? camposEntrada.Max(c => c.Right) : 310;
                int topPrimerCampo = camposEntrada.Any() ? camposEntrada.Min(c => c.Top) : 85;
                int bottomUltimoCampo = camposEntrada.Any() ? camposEntrada.Max(c => c.Bottom) : 320;

                int anchoGrupo = 215;
                int altoGrupo = 245;

                int ajusteX = 0;
                int ajusteY = 10;

                int panelX = bordeDerechoCampos + 25 + ajusteX;
                int panelY = topPrimerCampo + Math.Max(0, (bottomUltimoCampo - topPrimerCampo - altoGrupo) / 2) + ajusteY;

                int anchoFormulario = Math.Max(modal.ClientSize.Width, panelX + anchoGrupo + 30);
                int altoFormulario = Math.Max(modal.ClientSize.Height, panelY + altoGrupo + 70);
                modal.ClientSize = new Size(anchoFormulario, altoFormulario);

                var grpFoto = new GroupBox
                {
                    Name = "grpFotoVehiculo",
                    Text = "Fotografía del Vehículo",
                    ForeColor = Color.White,
                    BackColor = Color.FromArgb(45, 45, 48),
                    Size = new Size(anchoGrupo, altoGrupo),
                    Location = new Point(panelX, panelY)
                };

                var pic = new PictureBox
                {
                    Size = new Size(185, 120),
                    Location = new Point(15, 25),
                    SizeMode = PictureBoxSizeMode.Zoom,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    Image = CargarImagenCompleta(fotoInicial)
                };

                var cmbModelos = new ComboBox
                {
                    DropDownStyle = ComboBoxStyle.DropDownList,
                    Location = new Point(15, 155),
                    Size = new Size(185, 28)
                };
                cmbModelos.Items.AddRange(new object[]
                {
                    "auto_reciente_azul.png",
                    "auto_reciente_rojo.png",
                    "auto_viejito_verde.png",
                    "auto_viejito_ocre.png"
                });

                if (cmbModelos.Items.Contains(fotoInicial))
                    cmbModelos.SelectedItem = fotoInicial;
                else
                    cmbModelos.SelectedIndex = 0;

                cmbModelos.SelectedIndexChanged += (sender2, args2) =>
                {
                    if (cmbModelos.SelectedItem is string seleccion)
                    {
                        pic.Image?.Dispose();
                        pic.Image = CargarImagenCompleta(seleccion);
                        alCambiarFoto(seleccion);
                    }
                };

                var btnSubirPC = new Button
                {
                    Text = "Subir desde PC...",
                    Location = new Point(15, 192),
                    Size = new Size(185, 36),
                    FlatStyle = FlatStyle.Flat,
                    BackColor = Color.FromArgb(0, 122, 204),
                    ForeColor = Color.White,
                    Cursor = Cursors.Hand
                };
                btnSubirPC.FlatAppearance.BorderSize = 0;

                btnSubirPC.Click += (sender3, args3) =>
                {
                    using var ofd = new OpenFileDialog
                    {
                        Title = "Seleccionar fotografía del vehículo",
                        Filter = "Archivos de imagen (*.png;*.jpg;*.jpeg;*.bmp)|*.png;*.jpg;*.jpeg;*.bmp"
                    };

                    if (ofd.ShowDialog() == DialogResult.OK)
                    {
                        string nuevoArchivo = GuardarFotoDesdeArchivo(ofd.FileName);
                        pic.Image?.Dispose();
                        pic.Image = CargarImagenCompleta(nuevoArchivo);
                        alCambiarFoto(nuevoArchivo);
                    }
                };

                grpFoto.Controls.Add(pic);
                grpFoto.Controls.Add(cmbModelos);
                grpFoto.Controls.Add(btnSubirPC);
                modal.Controls.Add(grpFoto);
                grpFoto.BringToFront();
            }

            if (modal.IsHandleCreated)
                AgregarGrupo();
            else
                modal.Load += (s, e) => AgregarGrupo();
        }

        private static void CrearImagenAutoSiNoExiste(string nombreArchivo, Color colorCarro, string etiqueta, bool moderno)
        {
            string ruta = Path.Combine(CarpetaFotos, nombreArchivo);
            if (File.Exists(ruta)) return;

            using var bmp = new Bitmap(240, 145);
            using var g = Graphics.FromImage(bmp);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.Clear(Color.FromArgb(240, 244, 248));

            using var brushSombra = new SolidBrush(Color.FromArgb(210, 215, 220));
            using var brushCarro = new SolidBrush(colorCarro);
            using var brushVidrio = new SolidBrush(Color.FromArgb(200, 230, 255));
            using var brushLlanta = new SolidBrush(Color.FromArgb(35, 35, 35));
            using var brushRin = new SolidBrush(Color.Silver);

            g.FillEllipse(brushSombra, 25, 102, 190, 14);

            if (moderno)
            {
                g.FillRectangle(brushCarro, 28, 62, 184, 36);
                g.FillPolygon(brushCarro, new[]
                {
                    new Point(55, 62), new Point(88, 34),
                    new Point(160, 34), new Point(192, 62)
                });
                g.FillPolygon(brushVidrio, new[]
                {
                    new Point(65, 60), new Point(92, 39),
                    new Point(155, 39), new Point(182, 60)
                });
            }
            else
            {
                g.FillRectangle(brushCarro, 28, 64, 184, 34);
                g.FillPolygon(brushCarro, new[]
                {
                    new Point(65, 64), new Point(75, 36),
                    new Point(150, 36), new Point(162, 64)
                });
                g.FillPolygon(brushVidrio, new[]
                {
                    new Point(72, 61), new Point(80, 41),
                    new Point(145, 41), new Point(155, 61)
                });
            }

            g.FillEllipse(brushLlanta, 50, 80, 36, 36);
            g.FillEllipse(brushRin, 60, 90, 16, 16);
            g.FillEllipse(brushLlanta, 154, 80, 36, 36);
            g.FillEllipse(brushRin, 164, 90, 16, 16);

            using var font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
            using var brushTexto = new SolidBrush(Color.FromArgb(45, 45, 48));
            g.DrawString(etiqueta, font, brushTexto, new PointF(65, 122));

            bmp.Save(ruta);
        }
    }
}