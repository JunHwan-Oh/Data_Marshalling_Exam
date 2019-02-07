using DataMarshallingExam.BaseClasses;
using DataMarshallingExam.Components.MarshallingPanel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataMarshallingExam
{
    public class MainModel : ModelBase
    {
        MainView _view = null;

        MarshallView _marshallview = new MarshallView();

        public MarshallView Marshall_View { get { return _marshallview; } set { _marshallview = value; OnPropertyChanged(); } }

        public MainModel(MainView _view)
        {
            this._view = _view;
        }
    }
}
