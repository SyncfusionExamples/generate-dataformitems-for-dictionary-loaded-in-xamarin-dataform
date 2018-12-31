using Syncfusion.iOS.DataForm;
using System;
using System.Collections.Generic;
using UIKit;

namespace DataFormDictionary
{
    public partial class ViewController : UIViewController
    {
        public ViewController(IntPtr handle) : base(handle)
        {
        }

        Dictionary<string, object> formDictionary;
        public override void ViewDidLoad()
        {
            //  base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            var dataForm = new SfDataForm(new CoreGraphics.CGRect(0, 45, this.View.Frame.Width, this.View.Frame.Height));
            dataForm.DataObject = new object();

            var dictionary = new Dictionary<string, object>();
            dictionary.Add("ID", 1);
            dictionary.Add("Name", "John");

            formDictionary = dictionary;
            dataForm.ItemManager = new DataFormItemManagerExt(dataForm, dictionary);



            View.AddSubview(dataForm);
        }


        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}