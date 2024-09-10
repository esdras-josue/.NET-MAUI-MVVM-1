using System.ComponentModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;


namespace SumaAppMvvm.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string valor_1;
        private string valor_2;
        private string resultado;
        private string mensaje_error;

        public string Valor_1
        {
            get { return valor_1; }
            set
            {
                valor_1 = value;
                OnPropertyChanged(nameof(Valor_1));
            }
        }
        public string Valor_2
        {
            get { return valor_2; }
            set
            {
                valor_2 = value;
                OnPropertyChanged(nameof(Valor_2));
            }
        }
        public string Resultado
        {
            get { return resultado; }
            set
            {
                resultado = value;
                OnPropertyChanged(nameof(Resultado));
            }
        }
        public string Mensaje_error
        {
            get { return mensaje_error; }
            set
            {
                mensaje_error = value;
                OnPropertyChanged(nameof(Mensaje_error));
            }
        }

        public ICommand SumarCommand {  get; set; }
        public ICommand LimpiarCommand { get; set; }

        public MainViewModel()
        {
            SumarCommand = new Command(Sumar);
            LimpiarCommand = new Command(Limpiar);
        }
        private void Sumar()
        {
            Mensaje_error = string.Empty;
            if (string.IsNullOrEmpty(Valor_1) || string.IsNullOrEmpty(Valor_2))
            {
                mensaje_error = "Ambos campos son obligatorios.";
                return;
            }
            if (double.TryParse(Valor_1,out double numeroUno) && double.TryParse(valor_2,out double numeroDos))
            {
                resultado = (numeroUno + numeroDos).ToString();
            }
            else
            {
                Mensaje_error = "Por favor ingresar solo valores numericos";
            }
        }
        private void Limpiar()
        {
            Valor_1 = string.Empty;
            Valor_2 = string.Empty;
            Resultado = string.Empty;
            Mensaje_error = string.Empty;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

