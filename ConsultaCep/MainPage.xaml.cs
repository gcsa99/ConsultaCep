using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultaCep.Servico.Modelo;
using ConsultaCep.Servico;
namespace ConsultaCep
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Botao.Clicked += BuscarCEP;

        }
        private void BuscarCEP(object  sender, EventArgs  args) 
        {
            string cep = CEP.Text;

            if (isValidCEP(cep)){
                try
                {
                    Endereco end = ViaCEPServico.BuscaEnderecoViaCEP(cep);
                    if (end != null)
                    {
                        Resultado.Text = string.Format("Endereço:  {0}{4} {0}{3} {0}{2}, {1}", Environment.NewLine, end.uf, end.localidade, end.bairro, end.logradouro);
                    }
                    else
                    {
                        DisplayAlert("Erro no CEP", "O CEP informado não existe: " + cep, "ok");
                    }
                }
                catch (Exception ex) 
                {
                    DisplayAlert("Erro no sistema", ex.Message, "ok");
                }

               }
        }

        private bool isValidCEP(string cep)
        {
            bool valid = true;

            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido!  O CEP deve conter 8 números.", "OK");
                valid = false;
            }

            
            return valid;
        }
    }
}
