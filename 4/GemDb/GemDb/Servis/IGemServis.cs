using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GemDb.Servis
{
    public interface IGemServis
    {
        void Save (GemDTO packet);
        void FindAll ( ListBox listBox1 );
        void GetExistingColors ( ComboBox comboBoxColor );
        void FindGemWithColor ( string selectedItem, ListBox listBoxGem );
    }
}
