using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Syncfusion.iOS.DataForm;
using System.ComponentModel;

namespace DataFormDictionary
{
    public class DataFormItemManagerExt : DataFormItemManager
    {
        Dictionary<string, object> dataFormDict;
        public DataFormItemManagerExt(SfDataForm dataForm, Dictionary<string, object> dict) : base(dataForm)
        {
            dataFormDict = dict;
        }

        public override object GetValue(DataFormItem dataFormItem)
        {
            var value = dataFormDict[dataFormItem.Name];
            return value;
        }

        public override void SetValue(DataFormItem dataFormItem, object value)
        {
            dataFormDict[dataFormItem.Name] = value;
        }

        protected override List<DataFormItemBase> GenerateDataFormItems(PropertyDescriptorCollection itemProperties, List<DataFormItemBase> dataFormItems)
        {
            //return base.GenerateDataFormItems(itemProperties, dataFormItems);
            var items = new List<DataFormItemBase>();
            foreach (var key in dataFormDict.Keys)
            {
                DataFormItem dataFormItem;
                if (key == "ID")
                    dataFormItem = new DataFormNumericItem() { Name = key, Editor = "Numeric", MaximumNumberDecimalDigits = 0 };
                else if (key == "Name")
                    dataFormItem = new DataFormTextItem() { Name = key, Editor = "Text" };             
                else
                    dataFormItem = new DataFormTextItem() { Name = key, Editor = "Text" };

                items.Add(dataFormItem);
            }

            return items;
        }
    }
}