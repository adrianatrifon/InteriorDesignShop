USE HomeDesignDB

DECLARE @DesignId uniqueidentifier  
DECLARE @CategoryId uniqueidentifier
DECLARE @StyleId uniqueidentifier
DECLARE @DesignerId uniqueidentifier
DECLARE @PhotoId uniqueidentifier


SET @StyleId=NEWID()
EXECUTE dbo.Styles_Create @StyleID=@StyleId,@StyleName='Modern'
--EXECUTE dbo.Styles_Delete @StyleID='C108982A-2101-4145-84B1-CE733D7A245F'

SET @CategoryId=NEWID()
EXECUTE dbo.Categories_Create @CategoryID=@CategoryId, @ParentCategory=NULL,@CategoryName='Bathroom'
--EXECUTE dbo.Categories_Delete @CAtegoryID='224329B5-9137-42F0-ACEF-9F30991CF1C3'
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Bathroom1', @DesignDescription='A bathroom decorated with black exudes elegance and refinement. This Outlet tile and tile design project is complemented by Mallorca''s bathroom furniture. The shower cabin in Outlet keeps the contemporary note of the decor.',@CategoryID=@CategoryId,@StyleID=@StyleId
--EXECUTE dbo.Designs_Delete @DesignID='224329B5-9137-42F0-ACEF-9F30991CF1C3'
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Bathroom2', @DesignDescription='A modern-style bathroom with a natural color palette. A decorative tile from the Outlet Tile and Tile was chosen to suit the shower area and the washroom. The gray porcelain sandstone used for the floor is successfully combined with the sand-colored tile used for the other three walls.',@CategoryID=@CategoryId,@StyleID=@StyleId
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Bathroom3', @DesignDescription='The entire concept of this modern apartment in Eforie Nord has gone from the idea of composing an open, airy, sea-vibratory space. We chose a neutral but warm chromatic, with geometric textile accents, painted metal and lighting that highlight the furniture. The result is a relaxing holiday atmosphere that leads to \"home\"',@CategoryID=@CategoryId,@StyleID=@StyleId
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Bathroom4', @DesignDescription='Individual project for a villa in Cosmopolis. For the matrimonial bath, Mirage Dark ceramic tile collection from Venis Porcelanosa was proposed, along with the Bombay Silver mosaic and the Tuscan Stone gritstone.s.',@CategoryID=@CategoryId,@StyleID=@StyleId



SET @CategoryId=NEWID()
EXECUTE dbo.Categories_Create @CategoryID=@CategoryId, @ParentCategory=NULL,@CategoryName='Bedroom'
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Bedroom1', @DesignDescription='A bedroom in restful shades, which uses natural materials and finishes to create a pleasant atmosphere.',@CategoryID=@CategoryId,@StyleID=@StyleId
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Bedroom2', @DesignDescription='For this bedroom was chosen a simple and warm theme, with white and purple, uniquely decorated by the abstract paintings that offer the continuity of the two colors. The entire décor of the night area is worth the black curtains.',@CategoryID=@CategoryId,@StyleID=@StyleId
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Bedroom3', @DesignDescription='For customizing the bedroom, we choose decorations with geometric, floral or marine themes. A modern bedroom that is essentially characterized by Formmat furniture, personalized, with simple and low shapes, with delicate materials and a neutral chromatic gamut, animated by small intense color accents.',@CategoryID=@CategoryId,@StyleID=@StyleId
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Bedroom4', @DesignDescription='A modern bedroom with Formmat furniture, bed and bedding from Samoa, pallet bed made of oak veneer.',@CategoryID=@CategoryId,@StyleID=@StyleId

SET @CategoryId=NEWID()
EXECUTE dbo.Categories_Create @CategoryID=@CategoryId, @ParentCategory=NULL,@CategoryName='Kitchen'
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Kitchen1', @DesignDescription='In fashion designer Jenni Kayne’s Los Angeles home, the family can sit along a central island. The vintage French pendant fixtures are from Obsolete, and the stools are by DM/DM.',@CategoryID=@CategoryId,@StyleID=@StyleId
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Kitchen2', @DesignDescription='The mahogany-veneer cabinetry and laminate counters are original to this Malibu, California, house, restored by BoydDesign. The eat-in kitchen allows the whole family to be together while dinner is being prepared.',@CategoryID=@CategoryId,@StyleID=@StyleId
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Kitchen3', @DesignDescription='A Takashi Murakami work brightens the breakfast area of a Manhattan kitchen designed by David Kleinberg. The space has stainless-steel-and-milk-glass cabinetry and Calacatta gold marble counters and backsplashes. The pendant lights are by Poul Henningsen, and the sink fittings are by KWC.',@CategoryID=@CategoryId,@StyleID=@StyleId

SET @CategoryId=NEWID()
EXECUTE dbo.Categories_Create @CategoryID=@CategoryId, @ParentCategory=NULL,@CategoryName='Livingroom'
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Livingroom1', @DesignDescription='A transitional living room features a grand marble fireplace, high ceilings and a staircase. A white sectional and a pair of ottomans that can double as seating provide room for entertaining.',@CategoryID=@CategoryId,@StyleID=@StyleId
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Livingroom2', @DesignDescription='In designing this space the designer has managed to combine delicate yet modern materials and shades, making the most of the natural light abundant. The chromatic line of the entire arrangement is the perfect background for small interventions that personalize the home.',@CategoryID=@CategoryId,@StyleID=@StyleId
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Livingroom3', @DesignDescription='A contemporary-style living and dining room featuring personalized items: wall cladding and decorative panels on the ceiling. Vegetable elements bring a refreshing note of space. In the dining area, Wall & Deco wallpaper is noticeable.',@CategoryID=@CategoryId,@StyleID=@StyleId
SET @DesignId = NEWID()
EXECUTE dbo.Designs_Create @DesignID=@DesignId, @DesignName='Livingroom4', @DesignDescription='A bedroom in restful shades, which uses natural materials and finishes to create a pleasant atmosphere.',@CategoryID=@CategoryId,@StyleID=@StyleId
