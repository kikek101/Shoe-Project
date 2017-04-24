using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using csvShoes = ApplicationVariables.ApplicationVariables.DataIDs.CsvItems_Shoes;
using scl = ShoesClassLayer.ShoeClasses;
using LumenWorks.Framework.IO.Csv;
using System.IO;

namespace ShoesDataLayer 
{
    public class ShoesDataLayer : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose (bool disposing)
        {
            if(disposing)
            {

            }
        }

		//----------------------------------------------------CSV
		public scl.Shoes GetCsvData(string CsvPath)
        {
            scl.Shoes shoes = new scl.Shoes();

            using (CsvReader csv = new CsvReader(new StreamReader(CsvPath), true))
            {
                int fieldCount = csv.FieldCount;

                string[] headers = csv.GetFieldHeaders();
                while(csv.ReadNextRecord())
                {
                    if(shoes.Any(item => item.ShoeID == csv [csvShoes.ShoeID]))
                    {
                        scl.Shoe tmpShoe = shoes.Find(item => item.ShoeID == csv[csvShoes.ShoeID]);
                        if(tmpShoe.Designers.Any(item => item.DesignerID == csv [csvShoes.DesignerID]))
                        { }
                        else
                        {
                            scl.Designer designer = getDesignerFromCSV(csv);
                            tmpShoe.Designers.Add(designer);

                        }
                        if(tmpShoe.ShoeTypes.Any(item => item.ShoeTypeID == csv [csvShoes.ShoeTypeID]))
                        { }
                        else
                        {
                            scl.ShoeType shoeType = getShoeTypeFromCSV(csv);
                            tmpShoe.ShoeTypes.Add(shoeType);
                        }
                    }
                    else
                    {
                        scl.Shoe shoe = getShoeFromCSV(csv);
                        shoes.Add(shoe);
                    }
                }
            }
            return shoes;
        }

        private scl.Designer getDesignerFromCSV(CsvReader csv)
        {
            scl.Designer designer = new scl.Designer(csv[csvShoes.DesignerID]
                                                    , csv[csvShoes.DesignerName]);
            return designer;
        }

        private scl.ShoeType getShoeTypeFromCSV(CsvReader csv)
        {
            scl.ShoeType shoeType = new scl.ShoeType(csv[csvShoes.ShoeTypeID]
                                                    , csv[csvShoes.ShoeTypeName]);
            return shoeType;
        }

        private scl.Shoe getShoeFromCSV(CsvReader csv)
        {
            scl.Designer designer = getDesignerFromCSV(csv);
            scl.ShoeType shoeType = getShoeTypeFromCSV(csv);
            scl.Shoe shoe = new scl.Shoe(csv[csvShoes.ShoeID]
                                        ,csv[csvShoes.ShoeName]
                                        ,csv[csvShoes.ShoePrice]
										,csv[csvShoes.Colour]);
            shoe.Designers.Add(designer);
            shoe.ShoeTypes.Add(shoeType);
            return shoe;
        }
    }
}
