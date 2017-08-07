#region File Description
//-----------------------------------------------------------------------------
// Icons are predefined small images with few pre-defined icons. It has things
// like potions, shield, sword, etc.
//
// In addition, an icon comes with a built-in background that looks like an 
// inventory slot, that you can enable with the DrawBackground property.
//
// Note that you can easily make your own icons by overriding the 'Texture'
// property after creation. An Icon is just a subclass of the Image entity and
// extend its API.
//
// Author: Ronen Ness.
// Since: 2016.
//-----------------------------------------------------------------------------
#endregion
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using GeonBit.UI.DataTypes;

namespace GeonBit.UI.Entities
{
    /// <summary>
    /// A simple UI icon.
    /// Comes we a selection of pre-defined icons to use + optional inventory-like background.
    /// </summary>
    public class Icon : Image
    {
        /// <summary>If true, will draw inventory-like background to this icon.</summary>
        public bool DrawBackground = false;

        /// <summary>Default icon size for when no size is provided or when -1 is set for either width or height.</summary>
        new public static Vector2 DefaultSize = new Vector2(50f, 50f);

        /// <summary>Default styling for icons. Note: loaded from UI theme xml file.</summary>
        new public static StyleSheet DefaultStyle = new StyleSheet();

        /// <summary>
        /// Icon background size in pixels.
        /// </summary>
        public static int BackgroundSize = 10;

		/// <summary>
		/// Create a empty icon. Replace 'Texture' with your own texture.
		/// </summary>
		/// <param name="anchor">Position anchor.</param>
		/// <param name="scale">Icon default scale.</param>
		/// <param name="background">Weather or not to show icon inventory-like background.</param>
		/// <param name="offset">Offset from anchor position.</param>
		public Icon(Anchor anchor = Anchor.Auto, float scale = 1.0f, bool background = false, Vector2? offset = null) :
			base(null, USE_DEFAULT_SIZE, ImageDrawMode.Stretch, anchor, offset)
		{
			// set scale and basic properties
			Scale = scale;
			DrawBackground = background;
			Texture = null;

			// set default background color
			SetStyleProperty("BackgroundColor", new StyleProperty(Color.White));

			// if have background, add default space-after
			if(background)
			{
				SpaceAfter = Vector2.One * BackgroundSize;
			}

			// update default style
			UpdateStyle(DefaultStyle);
		}

		/// <summary>
		/// Create a new icon.
		/// </summary>
		/// <param name="iconName">Name of the icon to draw.</param>
		/// <param name="anchor">Position anchor.</param>
		/// <param name="scale">Icon default scale.</param>
		/// <param name="background">Weather or not to show icon inventory-like background.</param>
		/// <param name="offset">Offset from anchor position.</param>
		public Icon(string iconName, Anchor anchor = Anchor.Auto, float scale = 1.0f, bool background = false, Vector2? offset = null) :
            base(null, USE_DEFAULT_SIZE, ImageDrawMode.Stretch, anchor, offset)
        {
            // set scale and basic properties
            Scale = scale;
            DrawBackground = background;
            Texture = Resources.IconTextures[iconName];

            // set default background color
            SetStyleProperty("BackgroundColor", new StyleProperty(Color.White));

            // if have background, add default space-after
            if (background)
            {
                SpaceAfter = Vector2.One * BackgroundSize;
            }

            // update default style
            UpdateStyle(DefaultStyle);
        }

		/// <summary>
		/// Create a new icon.
		/// </summary>
		/// <param name="icon">The icon to draw.</param>
		/// <param name="anchor">Position anchor.</param>
		/// <param name="scale">Icon default scale.</param>
		/// <param name="background">Weather or not to show icon inventory-like background.</param>
		/// <param name="offset">Offset from anchor position.</param>
		public Icon(Texture2D icon, Anchor anchor = Anchor.Auto, float scale = 1.0f, bool background = false, Vector2? offset = null) :
			base(null, USE_DEFAULT_SIZE, ImageDrawMode.Stretch, anchor, offset)
		{
			// set scale and basic properties
			Scale = scale;
			DrawBackground = background;
			Texture = icon;

			// set default background color
			SetStyleProperty("BackgroundColor", new StyleProperty(Color.White));

			// if have background, add default space-after
			if(background)
			{
				SpaceAfter = Vector2.One * BackgroundSize;
			}

			// update default style
			UpdateStyle(DefaultStyle);
		}

		/// <summary>
		/// Draw the entity.
		/// </summary>
		/// <param name="spriteBatch">Sprite batch to draw on.</param>
		override protected void DrawEntity(SpriteBatch spriteBatch)
        {
            // draw background
            if (DrawBackground)
            {
                // get background dest rect
                Rectangle dest = _destRect;
                dest.X -= BackgroundSize / 2; dest.Y -= BackgroundSize / 2; dest.Width += BackgroundSize; dest.Height += BackgroundSize;
                UserInterface.Active.DrawUtils.DrawImage(spriteBatch, Resources.IconBackgroundTexture, dest, GetActiveStyle("BackgroundColor").asColor);
            }

            // now draw the image itself
            base.DrawEntity(spriteBatch);
        }
    }
}
