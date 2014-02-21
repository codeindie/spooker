/* File Description
 * Original Works/Author: Thomas Slusny
 * Other Contributors: None
 * Author Website: http://indiearmory.com
 * License: MIT
*/

using System;
using Gwen.Control;
using SFML.Graphics;
using SFML.Window;
using SFGL.Window;
using SFGL.Graphics;
using SFGL.Time;

namespace SFGL.GameStates
{
	/// <summary>
	/// Abstract class used for handling game input, drawing and updating for one scene.
	/// </summary>
	public abstract class State : GameComponent, IDrawable, IUpdateable
	{
		#region Properties
		/// <summary>
		/// Functions to call for this state when it is not the active state.
		/// </summary>
		public UpdateMode InactiveMode { get; protected set; }

		/// <summary>
		/// Returns true if this State is at the top of the State stack.
		/// </summary>
		public bool IsActive
		{
			get { return Game.IsActive(this); }
		}

		/// <summary>
		/// Overlay states are active when on top of the stack. The following non-overlay state will also be active.
		/// </summary>
		public bool IsOverlay { get; protected set; }
		#endregion

		#region Constructors and Destructors
		/// <summary>
		/// Creates new instance of game state.
		/// </summary>
		public State(GameWindow game) : base(game) 
		{
			InactiveMode = UpdateMode.All;
			IsOverlay = false;
		}
		#endregion

		#region Input bindings
		public virtual void TextEntered(TextEventArgs e) { }
		public virtual void MouseWheelMoved(MouseWheelEventArgs e) { }
		public virtual void MouseMoved(MouseMoveEventArgs e) { }
		public virtual void MouseButtonPressed(MouseButtonEventArgs e) { }
		public virtual void MouseButtonReleased(MouseButtonEventArgs e) { }
		public virtual void KeyPressed(KeyEventArgs e) { }
		public virtual void KeyReleased(KeyEventArgs e) { }
		#endregion

		#region Functions
		/// <summary>
		/// Called when a state is added to game (pushed to stack).
		/// </summary>
		public virtual void Enter() { }

		/// <summary>
		/// Called when a state is removed from game (popped from stack).
		/// </summary>
		public virtual void Leave() { }

		/// <summary>
		/// Update is called once every time step. 
		/// Game logic should be handled here (input, movement...)
		/// </summary>
		public virtual void Update(GameTime gameTime) { }

		/// <summary>
		/// Called once per frame. Avoid putting game logic in here.
		/// </summary>
		public virtual void Draw() { }
		#endregion
	}
}