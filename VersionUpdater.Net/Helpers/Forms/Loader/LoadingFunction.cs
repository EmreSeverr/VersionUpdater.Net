using System;
using System.Threading;
using System.Windows.Forms;

namespace VersionUpdater.Net.Helpers.Forms.Loader
{
    public class LoadingFunction
    {
        Loading _Loading;
        Thread _Thread;

        public void Apply(Action action)
        {
            Show();

            action.Invoke();

            Close();
        }

        public void Show()
        {
            _Thread = new Thread(new ThreadStart(LodaingProcess));
            _Thread.Start();
        }

        public void Show(Form parent)
        {
            _Thread = new Thread(new ParameterizedThreadStart(LodaingProcess));
            _Thread.Start();
        }

        public void Close()
        {
            if (_Loading != null)
            {
                _Loading.BeginInvoke(new ThreadStart(_Loading.CLoseLoaderForm));
                _Loading = null;
                _Thread = null;
            }
        }

        private void LodaingProcess()
        {
            _Loading = new Loading();
            _Loading.ShowDialog();
        }

        private void LodaingProcess(object parent)
        {
            Form? parent1 = parent as Form;
            _Loading = new Loading(parent1);
            _Loading.ShowDialog();
        }
    }
}
