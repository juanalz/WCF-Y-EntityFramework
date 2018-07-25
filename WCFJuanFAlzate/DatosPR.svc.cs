using System;
using System.Linq;

namespace WCFJuanFAlzate
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "DatosPR" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione DatosPR.svc o DatosPR.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class DatosPR : IDatosPR
    {
        public bool guardarPedidos(tblPedidos Pedidos)
        {
            try
            {
                db_ProductosRodandoEntities db = new db_ProductosRodandoEntities();
                db.tblPedidos.Add(Pedidos);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public tblPedidos[] consultarPedidos()
        {
            try
            {
                db_ProductosRodandoEntities db = new db_ProductosRodandoEntities();
                tblPedidos[] objPed;
                objPed = db.tblPedidos.ToArray();

                return objPed;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public bool editarPedidos(tblPedidos Pedidos)
        {
            try
            {
                db_ProductosRodandoEntities db = new db_ProductosRodandoEntities();
                var Pedi = (from ped in db.tblPedidos
                           where ped.NroFactura == Pedidos.NroFactura
                           select ped).First();

                Pedi.Cliente = Pedidos.Cliente;
                Pedi.DireccionEntrega = Pedidos.DireccionEntrega;
                Pedi.Fecha = Pedidos.Fecha;
                Pedi.Pagado = Pedidos.Pagado;
                Pedi.Producto = Pedidos.Producto;
                Pedi.TotalFactura = Pedidos.TotalFactura;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool eliminarPedidos(int NroFactura)
        {
            try
            {
                db_ProductosRodandoEntities db = new db_ProductosRodandoEntities();

                tblPedidos Pedidos = db.tblPedidos.Find(NroFactura);
                db.tblPedidos.Remove(Pedidos);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}