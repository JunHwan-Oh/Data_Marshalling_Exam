using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMarshallingExam
{
    public class MainViewModel
    {
        MainView _view = null;
        MainModel _model = null;

        public MainModel Model { get { return this._model; } }

        public MainViewModel(MainView _view)
        {
            this._view = _view;
            this._model = new MainModel(_view);
        }
    }
}
