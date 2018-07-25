using System.ServiceModel;

namespace WCFJuanFAlzate
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IDatosPR" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IDatosPR
    {
        [OperationContract]
        bool guardarPedidos(tblPedidos Pedidos);

        [OperationContract]
        tblPedidos[] consultarPedidos();

        [OperationContract]
        bool editarPedidos(tblPedidos Pedidos);

        [OperationContract]
        bool eliminarPedidos(int NroFactura);
    }
}
