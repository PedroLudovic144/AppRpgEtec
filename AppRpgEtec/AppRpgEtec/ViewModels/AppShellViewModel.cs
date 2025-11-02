using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppRpgEtec.Services.Usuarios;
using Azure.Storage.Blobs;



namespace AppRpgEtec.ViewModels
{
    public class AppShellViewModel : BaseViewModel
    {
        private UsuarioService uService;
        public AppShellViewModel()
        {
            string token = Preferences.Get("UsuarioToken", string.Empty);
            uService = new UsuarioService(token);
            CarregarUsuarioAzure();
        }

        private byte[] foto;
        public byte[] Foto
        {
            get => foto;
            set
            {
                foto = value;
                OnPropertyChanged();
            }
        }

        private string conexaoAzureStorage = "Minha_Chave";
        private string container = "arquivos";


        public async void CarregarUsuarioAzure()
        {
            try
            {
                int usuarioId = Preferences.Get("UsuarioId", 0);
                string fileName = $"{usuarioId}.jpg";

                // Cria cliente do container
                BlobContainerClient containerClient = new BlobContainerClient(conexaoAzureStorage, container);
                BlobClient blobClient = containerClient.GetBlobClient(fileName);

                if (await blobClient.ExistsAsync())
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        await blobClient.DownloadToAsync(ms);
                        Foto = ms.ToArray();
                    }
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + (ex.InnerException != null ? " Detalhes: " + ex.InnerException.Message : ""), "Ok");
            }
        }

    }
}
