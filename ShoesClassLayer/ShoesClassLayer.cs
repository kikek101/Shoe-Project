using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoesClassLayer 
{
	public class ShoeClasses 
	{
		//--------------------------------------------------------SHOES
		public class Shoes : List<Shoe> 
		{
			//----------------------------------------------------CONSTRUCTORS
			public Shoes() { }
			public Shoes(List<Shoe> shoes)
			{
			this.AddRange(shoes);
			}
			//----------------------------------------------------METHODS

			//----------------------------------------------------SHOES
			public Shoes GetShoesFilteredSubset(string shoeID, string shoeTypeID, string designerID, string shoePriceID, string colourID)
			{
			var tmpShoes = this.Where(s => s.ShoeID == ( ( shoeID == null ) ? s.ShoeID : shoeID ))
							   .Where(s => s.ShoeTypes.Any(a => a.ShoeTypeID == ( ( shoeTypeID == null ) ? a.ShoeTypeID : shoeTypeID )))
							   .Where(s => s.Designers.Any(a => a.DesignerID == ( ( designerID == null ) ? a.DesignerID : designerID )))
							   .Where(s => s.ShoePrice == ( ( shoePriceID == null ) ? s.ShoePrice : shoePriceID ))
							   .Where(s => s.Colour ==((colourID == null)? s.Colour : colourID))
							   .OrderBy(s => s.ShoeName)
							   .ThenBy(s => s.ShoeID)
							   .ToList();
			return new Shoes(tmpShoes);
			}

			public List<SimpleShoe> ToListSimpleShoe()
			{
			return this.Select(s => s.GetSimpleShoe()).OrderBy(s => s.ShoeName)
														  .ThenBy(s => s.ShoeID)
														  .ToList();
			}

			public List<SimpleShoe> GetDistinctSimpleShoe(string shoeID)
			{
			return this.Select(s => s.GetSimpleShoe()).Where(s => s.ShoeID == shoeID)
													  .ToList();
			}

			//----------------------------------------------------SHOE TYPE
			public List<ShoeType> ToListDistinctShoeType()
			{
			return this.SelectMany(a => a.ShoeTypes, (parent, child) => (ShoeType)( child.GetShoeType() )).GroupBy(a => a.ShoeTypeID)
																										.Select(grp => grp.First())
																										.OrderBy(a => a.ShoeTypeName)
																										.ThenBy(a => a.ShoeTypeID)
																										.ToList();
			}

			public List<ShoeType> GetDistinctShoeType(string shoeTypeID)
			{
			return this.SelectMany(p => p.ShoeTypes, (parent, child) => (ShoeType)( child.GetShoeType() )).Where(p => p.ShoeTypeID == shoeTypeID)
																										.GroupBy(p => p.ShoeTypeID)
																										.Select(grp => grp.First())
																										.ToList();
			}

			//----------------------------------------------------DESIGNERS
			public List<Designer> ToListDistinctDesigner()
			{
			return this.SelectMany(a => a.Designers, (parent, child) => (Designer)( child.GetDesigner() )).GroupBy(a => a.DesignerID)
																										.Select(grp => grp.First())
																										.OrderBy(a => a.DesignerName)
																										.ThenBy(a => a.DesignerID)
																										.ToList();
			}

			public List<Designer> GetDistinctDesigner(string designerID)
			{
			return this.SelectMany(p => p.Designers, (parent, child) => (Designer)( child.GetDesigner() )).Where(p => p.DesignerID == designerID)
																										.GroupBy(p => p.DesignerID)
																										.Select(grp => grp.First())
																										.ToList();
			}


			//----------------------------------------------------SHOE PRICES
			public List<ShoePrice> GetDistinctShoePrices()
			{
			var shoePrices = this.SelectMany(p => p.ShoePrice, (parent, child) => new ShoePrice(parent.ShoePrice, parent.ShoePrice))
																							.GroupBy(p => p.ShoePriceID)
																							.Select(grp => grp.First())
																							.OrderByDescending(x => x.ShoePriceValue)
																							.ThenBy(x => x.ShoePriceID)
																							.ToList();
			return shoePrices;

			}
			

		   //-----------------------------------------------------COLOUR
		   public List<Colour> GetDistinctColours()
		   {
			var colours = this.SelectMany(p => p.Colour, (parent, child) => new Colour(parent.Colour, parent.Colour))
																							.GroupBy(p => p.ColourID)
																							.Select(grp => grp.First())
																							.OrderByDescending(x => x.ShoeColour)
																							.ThenBy(x => x.ColourID)
																							.ToList();
			return colours;



			}

		}

		//----------------------------------------------------SHOE
		public class Shoe : SimpleShoe 
		{
			public List<ShoeType> ShoeTypes { get; set; }
			public List<Designer> Designers { get; set; }
			public string ShoePrice { get; set; }
			public string Colour { get; set; }

			public Shoe()
			{
			this.ShoeTypes = new List<ShoeType>();
			this.Designers = new List<Designer>();
			}

			//----------------------------------------------------CONSTRUCTORS
			public Shoe(string shoeID, string shoeName, string shoePrice, string colour) : base(shoeID, shoeName)
			{
			this.ShoeID = shoeID;
			this.ShoeName = shoeName;
			this.ShoeTypes = new List<ShoeType>();
			this.Designers = new List<Designer>();
			this.ShoePrice = shoePrice;
			this.Colour = colour;
			}

			public Shoe(string shoeID, string shoeName, List<ShoeType> shoeTypes, List<Designer> designers, string shoePrice, string colour)
																									 : base(shoeID, shoeName)
			{
			this.ShoeID = shoeID;
			this.ShoeName = shoeName;
			this.ShoeTypes = shoeTypes;
			this.Designers = designers;
			this.ShoePrice = shoePrice;
			this.Colour = colour;
			}
		}

		//----------------------------------------------------SIMPLE SHOE
		public class SimpleShoe 
		{
			public string ShoeID { get; set; }
			public string ShoeName { get; set; }

			//----------------------------------------------------CONSTRUCTORS
			public SimpleShoe() { }
			public SimpleShoe(string shoeID, string shoeName)
			{
			this.ShoeID = shoeID;
			this.ShoeName = shoeName;
			}

			//----------------------------------------------------METHODS
			public SimpleShoe GetSimpleShoe()
			{
			return (SimpleShoe)this;
			}
		}

		//----------------------------------------------------DESIGNER
		public class Designer 
		{
			public string DesignerID { get; set; }
			public string DesignerName { get; set; }

			//----------------------------------------------------CONSTRUCTORS
			public Designer() { }
			public Designer(string designerID, string designerName)
			{
			this.DesignerID = designerID;
			this.DesignerName = designerName;
			}

			//----------------------------------------------------METHODS
			public Designer GetDesigner()
			{
			return (Designer)this;
			}
		}

		//----------------------------------------------------SHOE TYPE
		public class ShoeType 
		{
			public string ShoeTypeID { get; set; }
			public string ShoeTypeName { get; set; }

			//----------------------------------------------------CONSTRUCTORS
			public ShoeType() { }
			public ShoeType(string shoeTypeID, string shoeTypeName)
			{
			this.ShoeTypeID = shoeTypeID;
			this.ShoeTypeName = shoeTypeName;
			}


			//----------------------------------------------------METHODS
			public ShoeType GetShoeType()
			{
			return (ShoeType)this;
			}
		}

		//----------------------------------------------------SHOE PRICE
		public class ShoePrice 
		{
			public string ShoePriceID { get; set; }
			public string ShoePriceValue { get; set; }

			//----------------------------------------------------CONSTRUCTORS
			public ShoePrice() { }
			public ShoePrice(string shoePriceID, string shoePriceValue)
			{
			this.ShoePriceID = shoePriceID;
			this.ShoePriceValue = shoePriceValue;
			}

			//----------------------------------------------------METHODS
			public ShoePrice GetShoePrice()
			{
			return (ShoePrice)this;
			}
		}

		public class Colour
		{
			public string ColourID { get; set; }
			public string ShoeColour { get; set; }

			//------------------------------------CONSTRUCTOR
			public Colour() { }
			public Colour(string colourID, string shoeColour) 
			{
			this.ColourID = colourID;
			this.ShoeColour = shoeColour;
			}
			
			//-------------------------------------METHOD
			public Colour GetColour()
			{
			return (Colour)this;
			}

		}
	}
}

