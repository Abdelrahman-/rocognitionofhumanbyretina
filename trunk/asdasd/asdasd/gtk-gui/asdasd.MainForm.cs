// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by a tool.
//      
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

namespace asdasd {
    
    
    public partial class MainForm {
        
        private Gtk.Table table1;
        
        private Gtk.Button button2;
        
        protected virtual void Build() {
            Stetic.Gui.Initialize(this);
            // Widget asdasd.MainForm
            this.Name = "asdasd.MainForm";
            this.Title = Mono.Unix.Catalog.GetString("MainForm");
            this.WindowPosition = ((Gtk.WindowPosition)(4));
            // Container child asdasd.MainForm.Gtk.Container+ContainerChild
            this.table1 = new Gtk.Table(((uint)(3)), ((uint)(3)), false);
            this.table1.Name = "table1";
            this.table1.RowSpacing = ((uint)(6));
            this.table1.ColumnSpacing = ((uint)(6));
            // Container child table1.Gtk.Table+TableChild
            this.button2 = new Gtk.Button();
            this.button2.CanFocus = true;
            this.button2.Name = "button2";
            this.button2.UseUnderline = true;
            this.button2.Label = Mono.Unix.Catalog.GetString("GtkButton");
            this.table1.Add(this.button2);
            Gtk.Table.TableChild w1 = ((Gtk.Table.TableChild)(this.table1[this.button2]));
            w1.TopAttach = ((uint)(1));
            w1.BottomAttach = ((uint)(2));
            w1.LeftAttach = ((uint)(1));
            w1.RightAttach = ((uint)(2));
            w1.XOptions = ((Gtk.AttachOptions)(4));
            w1.YOptions = ((Gtk.AttachOptions)(4));
            this.Add(this.table1);
            if ((this.Child != null)) {
                this.Child.ShowAll();
            }
            this.DefaultWidth = 400;
            this.DefaultHeight = 300;
            this.Show();
        }
    }
}
