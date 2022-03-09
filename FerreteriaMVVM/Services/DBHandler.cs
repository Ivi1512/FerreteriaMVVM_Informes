using FerreteriaMVVM.Models;
using FerreteriaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FerreteriaMVVM.Services
{
    public class DBHandler
    {
        #region Proveedores
        public static ObservableCollection<ProveedoresModel> listaProveedores { get; set; } = GetProveedores();

        private static ObservableCollection<ProveedoresModel> GetProveedores()
        {
            listaProveedores = new ObservableCollection<ProveedoresModel>();
            listaProveedores.Add(new ProveedoresModel("1", "Ikea", "Madrid", "912587457"));
            listaProveedores.Add(new ProveedoresModel("2", "Leroy Merlin", "Barcelona", "632251450"));
            listaProveedores.Add(new ProveedoresModel("3", "Amazon", "París", "567476123"));
            listaProveedores.Add(new ProveedoresModel("4", "Ferretería Manolo", "Seseña", "874632005"));
            return listaProveedores;
        }

        public static bool CrearProveedores(ProveedoresModel CurrentProveedor)
        {
            try
            {
                listaProveedores.Add(CurrentProveedor);
                MessageBox.Show("Proveedor " + CurrentProveedor.Nombre + " creado correctamente");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al crear el proveedor " + CurrentProveedor.Nombre + ". Error: " + e.Message);
                return false;
            }
        }

        public static bool EditarProveedores(ProveedoresModel CurrentProveedor)
        {
            try
            {
                foreach (ProveedoresModel p in listaProveedores)
                {
                    if (p._id.Equals(CurrentProveedor._id))
                    {
                        p.Nombre = CurrentProveedor.Nombre;
                        p.Poblacion = CurrentProveedor.Poblacion;
                        p.Telefono = CurrentProveedor.Telefono;
                        break;
                    }
                }
                MessageBox.Show("Proveedor " + CurrentProveedor.Nombre + " editado correctamente");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al editar el proveedor " + CurrentProveedor.Nombre + ". Error: " + e.Message);
                return false;
            }
        }

        public static bool BorrarProveedores(ProveedoresModel CurrentProveedor)
        {
            try
            {
                foreach (ProveedoresModel p in listaProveedores)
                {
                    if (p._id.Equals(CurrentProveedor._id))
                    {
                        listaProveedores.Remove(p);
                        break;
                    }
                }

                foreach (ProductosModel producto in listaProductos)
                {
                    foreach (ProveedoresModel proveedor in producto.Proveedores)
                    {
                        if(proveedor._id.Equals(CurrentProveedor._id))
                        {
                            producto.Proveedores.Remove(proveedor);
                            break;
                        }
                    }
                }

                MessageBox.Show("Proveedor " + CurrentProveedor.Nombre + " borrado correctamente");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al eliminar el proveedor " + CurrentProveedor.Nombre + ". Error: " + e.Message);
                return false;
            }
        }
        #endregion

        #region Productos
        public static ObservableCollection<ProductosModel> listaProductos { get; set; } = GetProductos();

        private static ObservableCollection<ProductosModel> GetProductos()
        {
            listaProductos = new ObservableCollection<ProductosModel>();

            var random = new Random();
            var listCategoria = GetCategorias();
            var listMarca = GetMarcas();
            var listMaterial = GetMateriales();

            for (int i = 1; i < 10; i++)
            {
                int indexCategoria = random.Next(listCategoria.Count);
                int indexMarca = random.Next(listMarca.Count);
                int indexMaterial = random.Next(listMaterial.Count);

                ProductosModel p = new ProductosModel();
                p._id = i.ToString();
                p.Categoria = listCategoria[indexCategoria];
                p.Marca = listMarca[indexMarca];
                p.Material = listMaterial[indexMaterial];
                p.Referencia = "00" + i;
                p.Descripcion = "Este es el producto " + p.Referencia;
                p.Precio = 10.5 * i;
                p.FechaEntrada = DateTime.Today;
                p.Stock = 10 * i;

                int numeroProveedores = random.Next(1, listaProveedores.Count);
                for (int j = 0; j < numeroProveedores; j++)
                {
                    int indexProveedor = random.Next(listaProveedores.Count);
                    if(!p.Proveedores.Contains(listaProveedores[indexProveedor]))
                    {
                        p.Proveedores.Add(listaProveedores[indexProveedor]);
                    }
                }

                listaProductos.Add(p);
            }
            return listaProductos;
        }

        public static bool CrearProductos(ProductosModel CurrentProducto)
        {
            try
            {
                listaProductos.Add(CurrentProducto);
                MessageBox.Show("Producto " + CurrentProducto.Nombre + " creado correctamente");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al crear el producto " + CurrentProducto.Nombre + ". Error: " + e.Message);
                return false;
            }
        }

        public static bool EditarProductos(ProductosModel CurrentProducto)
        {
            try
            {
                foreach (ProductosModel p in listaProductos)
                {
                    if (p._id.Equals(CurrentProducto._id))
                    {
                        p.Proveedores = CurrentProducto.Proveedores;
                        p.Categoria = CurrentProducto.Categoria;
                        p.Marca = CurrentProducto.Marca;
                        p.Material = CurrentProducto.Material;
                        p.Referencia = CurrentProducto.Referencia;
                        p.Descripcion = CurrentProducto.Descripcion;
                        p.Precio = CurrentProducto.Precio;
                        p.FechaEntrada = CurrentProducto.FechaEntrada;
                        p.Stock = CurrentProducto.Stock;
                        break;
                    }
                }
                MessageBox.Show("Producto " + CurrentProducto.Nombre + " editado correctamente");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al editar el producto " + CurrentProducto.Nombre + ". Error: " + e.Message);
                return false;
            }
        }

        public static bool BorrarProductos(ProductosModel CurrentProducto)
        {
            try
            {
                foreach (ProductosModel p in listaProductos)
                {
                    if (p._id.Equals(CurrentProducto._id))
                    {
                        listaProductos.Remove(p);
                        break;
                    }
                }
                MessageBox.Show("Producto " + CurrentProducto.Nombre + " borrado correctamente");
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Error al borrar el producto " + CurrentProducto.Nombre + ". Error: " + e.Message);
                return false;
            }
        }
        #endregion


        public static ObservableCollection<ProductosModel> ActualizarTabla(string palabraFiltro)
        {
            try
            {
                ObservableCollection<ProductosModel> listaProductosFiltro = new ObservableCollection<ProductosModel>();

                foreach (ProductosModel producto in listaProductos)
                {

                    if (producto._id.ToLower().Contains(palabraFiltro.ToLower()) ||
                        producto.Referencia.ToLower().Contains(palabraFiltro.ToLower()) ||
                        producto.Descripcion.ToLower().Contains(palabraFiltro.ToLower()) ||
                        producto.Precio.ToString().ToLower().Contains(palabraFiltro.ToLower()) ||
                        producto.Stock.ToString().ToLower().Contains(palabraFiltro.ToLower()))
                    {
                        listaProductosFiltro.Add(producto);
                    }
                    else
                    {
                        foreach (ProveedoresModel proveedor in producto.Proveedores)
                        {
                            if (!listaProductosFiltro.Contains(producto) && proveedor.Nombre.ToLower().Contains(palabraFiltro.ToLower()))
                            {
                                listaProductosFiltro.Add(producto);
                            }
                        }
                    }

                }

                return listaProductosFiltro;
            }
            catch(Exception e)
            {
                MessageBox.Show("Error al filtrar la lista: " + e);
                return listaProductos;
            }
            
        }

        public static ObservableCollection<string> GetCategorias()
        {
            ObservableCollection<string> listCategorias = new ObservableCollection<string>();
            listCategorias.Add("Llaves");
            listCategorias.Add("Herramientas");
            listCategorias.Add("Calefacción");
            listCategorias.Add("Electricidad");
            listCategorias.Add("Tornillería");

            return listCategorias;
        }

        public static ObservableCollection<string> GetMarcas()
        {
            ObservableCollection<string> listMarcas = new ObservableCollection<string>();
            listMarcas.Add("Wurt");
            listMarcas.Add("Palmera");
            listMarcas.Add("Bosch");
            listMarcas.Add("Still");

            return listMarcas;

        }

        public static ObservableCollection<string> GetMateriales()
        {
            ObservableCollection<string> listMateriales= new ObservableCollection<string>();
            listMateriales.Add("Aluminio");
            listMateriales.Add("Cobre");
            listMateriales.Add("Latón");
            listMateriales.Add("Inoxidable");
            listMateriales.Add("Plástico");

            return listMateriales;
        }
    }
}
