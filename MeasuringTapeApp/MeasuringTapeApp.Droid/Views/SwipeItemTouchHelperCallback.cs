using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MeasuringTapeApp.Services;
using MeasuringTapeApp.ViewModels;
using MvvmCross.Navigation;
using Android.App;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V7.Widget;
using Android.Support.V7.Widget.Helper;

namespace MeasuringTapeApp.Droid.Views
{
    public class SwipeItemTouchHelperCallback : ItemTouchHelper.SimpleCallback
    {

        readonly ListViewModel viewModel;
        public SwipeItemTouchHelperCallback(ListViewModel viewModel)
            : base(0, ItemTouchHelper.Start)
        {
            this.viewModel = viewModel;
            
        }

        public override bool OnMove(RecyclerView recyclerView,
                            RecyclerView.ViewHolder viewHolder,
                            RecyclerView.ViewHolder target)
        {
            return true;
        }

        public override void OnSwiped(RecyclerView.ViewHolder viewHolder, int direction)
        {

            viewModel.DeleteObjectFromDatabase(viewModel.MeasuredObjects[viewHolder.AdapterPosition]);
            viewModel.MeasuredObjects.Remove(viewModel.MeasuredObjects[viewHolder.AdapterPosition]);
            //measuringStorageService.DeleteObject(viewModel.MeasuredObjects[viewHolder.AdapterPosition]);

            
        }

        readonly Drawable background = new ColorDrawable(Color.Rgb(255, 114, 114));
        Drawable background2 = new ColorDrawable(Color.White);

        public override void OnChildDraw(Canvas c, RecyclerView recyclerView,
                                         RecyclerView.ViewHolder viewHolder,
                                         float dX, float dY, int actionState,
                                         bool isCurrentlyActive)
        {
            background.SetBounds(viewHolder.ItemView.Right + (int)dX,
                                  viewHolder.ItemView.Top,
                                  viewHolder.ItemView.Right,
                                  viewHolder.ItemView.Bottom);
            background.Draw(c);

            base.OnChildDraw(c, recyclerView, viewHolder, dX, dY,
                             actionState, isCurrentlyActive);

        }
    }
}