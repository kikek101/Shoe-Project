using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationVariables	
{
	public class ApplicationVariables
	{
		public ApplicationVariables()
		{ }

		public struct CsvPaths 
		{
			public static string ShoesCSV = @"C:\Users\Novus\Documents\ShoeProjectWithTable\MyProject\WebApplication1\Shoes CSV.csv";
		}
		public struct ExternalResources
		{
			public static string AmazonLink = "https://Amazon.co.uk/dp/";
		 }

		public struct SystemSettings 
		{
			public struct Cache 
			{
				public static bool UseCache = true;
				public static string ShoeCacheName = @"cache_Shoe";
			}
		}
		public struct SystemValues	
		{
			public struct Buttons		
			{
				public static string BtnResetID_ToLower = "btnreset";
			}

			public struct DropDownLists 
			{
				public static string DefaultValue = @"NOT SELECTED";
				public static string DefaultText = @"<----- SELECT ----->";
				public static bool UseBlankItem = true;

				public struct Shoes 
				{
					public static string ControlID = @"DropDownListShoes";
					public static string DataTextField = @"ShoeName";
					public static string DataValueField = @"ShoeID";
				}

				public struct ShoeTypes
			    {
					public static string ControlID = @"DropDownListShoeTypes";
					public static string DataTextField = @"ShoeTypeName";
					public static string DataValueField = @"ShoeTypeID";
				}

				public struct Designers
			    {
					public static string ControlID = @"DropDownListDesigners";
					public static string DataTextField = @"DesignerName";
					public static string DataValueField = @"DesignerID";
				}

				public struct ShoePrices 
				{
					public static string ControlID = @"DropDownListShoePrices";
					public static string DataTextField = @"ShoePriceValue";
					public static string DataValueField = @"ShoePriceID";
				}
				
				public struct Colours
				{
					public static string ControlID = @"DropDownListColours";
					public static string DataTextField = @"ShoeColour";
					public static string DataValueField = @"ColourID";
				}
			}
		}
		public struct DataIDs 
		{
			public struct CsvItems_Shoes 
			{
				public static int ShoeID = 0;
				public static int ShoeName = 1;
				public static int ShoePrice = 6;
				public static int DesignerID = 4;
				public static int DesignerName = 5;
				public static int ShoeTypeID = 2;
				public static int ShoeTypeName = 3;
				public static int Colour = 7;
			}
		}
	}
}
