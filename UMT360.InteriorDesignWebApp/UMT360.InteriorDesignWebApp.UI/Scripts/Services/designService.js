var DesignService = function() {
    _designs = [
        {
            Id: "rd1",
            Name: "Bathroom1",
            Description: "A bathroom decorated with black exudes elegance and refinement. This Outlet tile and tile design project is complemented by Mallorca\'s bathroom furniture. The shower cabin in Outlet keeps the contemporary note of the decor.",
            CategoryId: "cat1",
            StyleId: "s1"
        },
        {
            Id: "rd2",
            Name: "Bathroom2",
            Description: "A modern-style bathroom with a natural color palette. A decorative tile from the Outlet Tile and Tile was chosen to suit the shower area and the washroom. The gray porcelain sandstone used for the floor is successfully combined with the sand-colored tile used for the other three walls.",
            CategoryId: "cat1",
            StyleId: "s1"
        },
        {
            Id: "rd3",
            Name: "Bathroom3",
            Description: "The entire concept of this modern apartment in Eforie Nord has gone from the idea of composing an open, airy, sea-vibratory space. We chose a neutral but warm chromatic, with geometric textile accents, painted metal and lighting that highlight the furniture. The result is a relaxing holiday atmosphere that leads to \"home",
            CategoryId: "cat1",
            StyleId: "s1"
        },
        {
            Id: "rd4",
            Name: "Bathroom4",
            Description: "Individual project for a villa in Cosmopolis. For the matrimonial bath, Mirage Dark ceramic tile collection from Venis Porcelanosa was proposed, along with the Bombay Silver mosaic and the Tuscan Stone gritstone.s.",
            CategoryId: "cat1",
            StyleId: "s1"
        },
        {
            Id: "rd5",
            Name: "Kitchen1",
            Description: "In fashion designer Jenni Kayne’s Los Angeles home, the family can sit along a central island. The vintage French pendant fixtures are from Obsolete, and the stools are by DM/DM.",
            CategoryId: "cat3",
            StyleId: "s1"
        },
        {
            Id: "rd6",
            Name: "Kitchen2",
            Description: "The mahogany-veneer cabinetry and laminate counters are original to this Malibu, California, house, restored by BoydDesign. The eat-in kitchen allows the whole family to be together while dinner is being prepared.",
            CategoryId: "cat3",
            StyleId: "s1"
        },
        {
            Id: "rd7",
            Name: "Kitchen3",
            Description: "A Takashi Murakami work brightens the breakfast area of a Manhattan kitchen designed by David Kleinberg. The space has stainless-steel-and-milk-glass cabinetry and Calacatta gold marble counters and backsplashes. The pendant lights are by Poul Henningsen, and the sink fittings are by KWC.",
            CategoryId: "cat3",
            StyleId: "s1"
        },
        {
            Id: "rd8",
            Name: "Livingroom1",
            Description: "A transitional living room features a grand marble fireplace, high ceilings and a staircase. A white sectional and a pair of ottomans that can double as seating provide room for entertaining.",
            CategoryId: "cat4",
            StyleId: "s1"
        },
        {
            Id: "rd9",
            Name: "Livingroom2",
            Description: "In designing this space the designer has managed to combine delicate yet modern materials and shades, making the most of the natural light abundant. The chromatic line of the entire arrangement is the perfect background for small interventions that personalize the home.",
            CategoryId: "cat4",
            StyleId: "s1"
        },
        {
            Id: "rd10",
            Name: "Livingroom3",
            Description: "A proposal for a living room for an apartment in Cortina Residence. Customized Formmat furniture and Flexmat chairs were used. The turquoise and yellow accents create a pleasant atmosphere.",
            CategoryId: "cat4",
            StyleId: "s1"
        },
        {
            Id: "rd11",
            Name: "Livingroom4",
            Description: "A contemporary-style living and dining room featuring personalized items: wall cladding and decorative panels on the ceiling. Vegetable elements bring a refreshing note of space. In the dining area, Wall & Deco wallpaper is noticeable.",
            CategoryId: "cat4",
            StyleId: "s1"
        },
        {
            Id: "rd12",
            Name: "Bedroom1",
            Description: "A bedroom in restful shades, which uses natural materials and finishes to create a pleasant atmosphere.",
            CategoryId: "cat2",
            StyleId: "s1"
        },
        {
            Id: "rd13",
            Name: "Bedroom2",
            Description: "For this bedroom was chosen a simple and warm theme, with white and purple, uniquely decorated by the abstract paintings that offer the continuity of the two colors. The entire décor of the night area is worth the black curtains.",
            CategoryId: "cat2",
            StyleId: "s1"
        },
        {
            Id: "rd14",
            Name: "Bedroom3",
            Description: "For customizing the bedroom, we choose decorations with geometric, floral or marine themes. A modern bedroom that is essentially characterized by Formmat furniture, personalized, with simple and low shapes, with delicate materials and a neutral chromatic gamut, animated by small intense color accents.",
            CategoryId: "cat2",
            StyleId: "st1"
        },
        {
            Id: "rd15",
            Name: "Bedroom4",
            Description: "A modern bedroom with Formmat furniture, bed and bedding from Samoa, pallet bed made of oak veneer.",
            CategoryId: "cat2",
            StyleId: "s1"
        }
    ];

    this.ReadAll = function() {
        return _designs;
    };

    this.ReadById = function(id) {
        for (var index = 0; index < _designs.lenght; index++) {
            if (_designs[index].Id === id) {
                return _designs[index];
            }
        }
        return null;
    };
};