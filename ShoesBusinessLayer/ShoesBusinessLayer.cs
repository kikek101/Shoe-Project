using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using scl = ShoesClassLayer.ShoeClasses;
using sdl = ShoesDataLayer.ShoesDataLayer;

namespace ShoesBusinessLayer
{
    public class ShoesBusinessLayer : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if(disposing)
            {

            }
        }

        public scl.Shoes GetShoes(string csvPath)
        {
            using (sdl dl1 = new sdl())
            {
                return dl1.GetCsvData(csvPath);
            }
		//----------------------------------------------------SIMPLE SHOES
		}
		public List<scl.SimpleShoe> GetDistinctSimpleShoesFromShoes(scl.Shoes shoes)
        {
            return (shoes == null) ? null : shoes.ToListSimpleShoe();
        }

        public List<scl.SimpleShoe> GetDistinctSimpleShoe(scl.Shoes shoes, string shoeID)
        {
            return shoes.GetDistinctSimpleShoe(shoeID);
        }
        public scl.Shoes GetShoesSubset(string shoeID, string designerID, string shoeTypeID, string shoePriceID,string colourID, scl.Shoes shoes )
        {
            return shoes.GetShoesFilteredSubset(shoeID, designerID, shoeTypeID,shoePriceID, colourID);
        }
		//----------------------------------------------------DESIGNERS

		public List<scl.Designer> GetDistinctDesignersFromShoes(scl.Shoes shoes)
        {
            return (shoes == null) ? null : shoes.ToListDistinctDesigner();
        }
        public List<scl.Designer> GetDistinctDesigner(scl.Shoes shoes, string designerID)
        {
            return shoes.GetDistinctDesigner(designerID);
        }

		//----------------------------------------------------SHOE TYPES

		public List<scl.ShoeType> GetDistinctShoeTypesFromShoes(scl.Shoes shoes)
        {
            return (shoes == null) ? null : shoes.ToListDistinctShoeType();
        }

        public List<scl.ShoeType> GetDistinctShoeType(scl.Shoes shoes, string shoeTypeID)
        {
            return shoes.GetDistinctShoeType(shoeTypeID);
        }
		//----------------------------------------------------SHOE PRICES

		public List<scl.ShoePrice> GetDistinctShoePricesFromShoes(scl.Shoes shoes)
        {
            return (shoes == null) ? null : shoes.GetDistinctShoePrices();
        }
	
		//----------------------------------------------------COLOURS
		public List<scl.Colour> GetDistinctColoursFromShoes(scl.Shoes shoes)
		{
			return ( shoes == null ) ? null : shoes.GetDistinctColours();
		}
    }
}
