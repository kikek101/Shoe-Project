using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using av = ApplicationVariables.ApplicationVariables;
using cache = ApplicationVariables.ApplicationVariables.SystemSettings.Cache;
using ddl = ApplicationVariables.ApplicationVariables.SystemValues.DropDownLists;
using sbl = ShoesBusinessLayer.ShoesBusinessLayer;
using scl = ShoesClassLayer.ShoeClasses;

namespace WebShoes
{
    public partial class Default : SharedBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.IsPostBack && isFilteredPageLoad())
            {
                using (sbl bl1 = new sbl())
                {
                    string shoeID = (DropDownListShoes.SelectedValue == av.SystemValues.DropDownLists.DefaultValue 
                                                                                            ? null : DropDownListShoes.SelectedValue);
                    string shoeTypeID = (DropDownListShoeTypes.SelectedValue == av.SystemValues.DropDownLists.DefaultValue 
                                                                                            ? null : DropDownListShoeTypes.SelectedValue);
                    string desingerID = (DropDownListDesigners.SelectedValue == av.SystemValues.DropDownLists.DefaultValue 
                                                                                            ? null : DropDownListDesigners.SelectedValue);
                    string shoePriceID = (DropDownListShoePrices.SelectedValue == av.SystemValues.DropDownLists.DefaultValue 
                                                                                            ? null : DropDownListShoePrices.SelectedValue);
					string colourID = ( DropDownListColours.SelectedValue == av.SystemValues.DropDownLists.DefaultValue
																							? null : DropDownListColours.SelectedValue );
                   
				    populateDropDownsWithFilteredData(shoeID, shoeTypeID, desingerID, shoePriceID, colourID);
                }
            }
            else
            {
                populateDropDownsWithOriginalData();
            }
        }
        
        private bool isFilteredPageLoad()
        {
            return (Page.Request.Params["__EVENTTARGET"].ToLower() != av.SystemValues.Buttons.BtnResetID_ToLower);
        }

        private void populateDropDowns(bool addBlankItem , List<scl.SimpleShoe> sShoes
                                                         , List<scl.ShoeType> shoeTypes
                                                         , List<scl.Designer> designers
                                                         , List<scl.ShoePrice> shoePrices
														 , List<scl.Colour> colours)
        {
            populateDropDownList(true, ddl.Shoes.ControlID
                                                        , sShoes
                                                        , ddl.Shoes.DataTextField
                                                        , ddl.Shoes.DataValueField);
            populateDropDownList(true, ddl.ShoeTypes.ControlID
                                                          , shoeTypes
                                                          , ddl.ShoeTypes.DataTextField
                                                          , ddl.ShoeTypes.DataValueField);
            populateDropDownList(true, ddl.Designers.ControlID
                                                          , designers
                                                          , ddl.Designers.DataTextField
                                                          , ddl.Designers.DataValueField);
            populateDropDownList(true, ddl.ShoePrices.ControlID
                                                          , shoePrices
                                                          , ddl.ShoePrices.DataTextField
                                                          , ddl.ShoePrices.DataValueField);
			populateDropDownList(true, ddl.Colours.ControlID
														  , colours
														  , ddl.Colours.DataTextField
														  , ddl.Colours.DataValueField);

        }

        private scl.Shoes getShoes()
        {
           scl.Shoes shoes  = new scl.Shoes();

            if((cache.UseCache) && (Cache[cache.ShoeCacheName] != null))
                {

                shoes = Cache[cache.ShoeCacheName] as scl.Shoes;
                }
            else 
            {
                using (sbl bl1 = new sbl())
                {
                    shoes = bl1.GetShoes(av.CsvPaths.ShoesCSV);
                    if (cache.UseCache) Cache[cache.ShoeCacheName] = shoes;
                }
            }

            return shoes;
        }

        private void populateDropDownsWithOriginalData()
        {
            using (sbl bl1 = new sbl())
            {
                scl.Shoes shoes = getShoes();

                List<scl.SimpleShoe> sShoes = bl1.GetDistinctSimpleShoesFromShoes(shoes);
                List<scl.ShoeType> shoeTypes = bl1.GetDistinctShoeTypesFromShoes(shoes);
                List<scl.Designer> designers = bl1.GetDistinctDesignersFromShoes(shoes);
                List<scl.ShoePrice> shoePrices = bl1.GetDistinctShoePricesFromShoes(shoes);
				List<scl.Colour> colours = bl1.GetDistinctColoursFromShoes(shoes);

                populateDropDowns(ddl.UseBlankItem, sShoes, shoeTypes, designers,shoePrices, colours);
            }
        }

        private void populateDropDownsWithFilteredData(string shoeID, string shoeTypeID, string designerID, string shoePriceID, string colourID)
        {
            scl.Shoes shoes = getShoes();
            using (sbl bl1 = new sbl())
            { 
                scl.Shoes tmp = bl1.GetShoesSubset(shoeID, shoeTypeID, designerID, shoePriceID,colourID, shoes);
                
                List<scl.SimpleShoe> sShoes = (shoeID == null) ? bl1.GetDistinctSimpleShoesFromShoes(tmp) 
																: bl1.GetDistinctSimpleShoe(tmp, shoeID);
                List<scl.ShoeType> shoeTypes = (shoeTypeID == null) ? bl1.GetDistinctShoeTypesFromShoes(tmp)
															    : bl1.GetDistinctShoeType(tmp, shoeTypeID);
                List<scl.Designer> designers = (designerID == null) ? bl1.GetDistinctDesignersFromShoes(tmp) 
																: bl1.GetDistinctDesigner(tmp, designerID);
                List<scl.ShoePrice> shoePrices = (shoePriceID == null) ? bl1.GetDistinctShoePricesFromShoes(tmp)
															    : tmp.GetDistinctShoePrices();
				List<scl.Colour> colours = ( colourID == null ) ? bl1.GetDistinctColoursFromShoes(tmp)
																: tmp.GetDistinctColours();               
				
			populateDropDowns(ddl.UseBlankItem, sShoes, shoeTypes, designers, shoePrices, colours);

                if (tmp.Count == 1) { showFilterResult(sShoes, shoeTypes, designers, shoePrices, colours); }

            }

        }

		private void showFilterResult(List<scl.SimpleShoe> sShoes
																, List<scl.ShoeType> shoeTypes
																, List<scl.Designer> designers
																, List<scl.ShoePrice> shoePrices
																, List<scl.Colour> colours) 
		{
		HyperLink link = new HyperLink();
		link.NavigateUrl =av.ExternalResources.AmazonLink + sShoes[0].ShoeID;
		link.Text = sShoes[0].ShoeName;
		cellShoeName.Controls.Add(link);
		cellShoeID.Text = sShoes[0].ShoeID;
		cellShoeTypeID.Text = shoeTypes[0].ShoeTypeID;
		cellShoeType.Text = shoeTypes[0].ShoeTypeName;
		cellDesignerID.Text = designers[0].DesignerID;
		cellDesignerName.Text = designers[0].DesignerName;
		cellShoePrice.Text = shoePrices[0].ShoePriceValue;
		cellColour.Text = colours[0].ShoeColour;
	
		
			if (sShoes.Count == 1 && shoeTypes.Count == 1 && designers.Count == 1 && shoePrices.Count == 1 && colours.Count == 1)
			{	
				tblShoeResult.Visible = true; 
			}
			
		}

        private void clearFilterResult()
        {
            cellShoeID.Text = string.Empty;
            cellShoeName.Text = string.Empty;
            cellShoeTypeID.Text = string.Empty;
			cellShoeType.Text = string.Empty;
			cellDesignerID.Text = string.Empty;
			cellDesignerName.Text = string.Empty;
			cellShoePrice.Text = string.Empty;
			cellColour.Text = string.Empty;
			tblShoeResult.Visible = false;
        }

        protected void btnReset_Click(object sender , EventArgs e)
        {
            clearFilterResult();
            populateDropDownsWithOriginalData();
        }
    }
}
