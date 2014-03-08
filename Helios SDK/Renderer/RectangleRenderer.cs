﻿//  Copyright 2013 Craig Courtney
//    
//  Helios is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  Helios is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

namespace GadrocsWorkshop.Helios.Renderer
{
    using System;

    using SharpDX;
    using SharpDX.Direct2D1;

    using GadrocsWorkshop.Helios.Runtime;
    using GadrocsWorkshop.Helios.Util;
    using GadrocsWorkshop.Helios.Visuals;

    internal class RectangleRenderer : StateRenderer<RectangleVisual>
    {
        private bool _disposed;
        private SolidColorBrush Brush;

        public RectangleRenderer(VisualState state)
            : base(state)
        {
        }

        protected override void OnRenderBeforeChildren(RenderTarget target)
        {
            if (Brush == null)
            {
                Brush = new SolidColorBrush(target, new Color4(State.Color.Int));

            }
            target.FillRectangle(BoundingRectangle, Brush);
        }

        protected override void OnRenderAfterChildren(RenderTarget target)
        {
            // NO-Op
        }

        protected override void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                Disposer.RemoveAndDispose(ref Brush);
                _disposed = true;
            }
        }
    }
}