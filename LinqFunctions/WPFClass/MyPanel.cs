using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace LinqFunctions.WPFClass
{
    #region Solution
    //class MyPanel : Panel
    //{
    //    private List<Visual> visuals = new List<Visual>();
    //    protected override Visual GetVisualChild(int index)
    //    {
    //        return visuals[index];
    //    }
    //    protected override int VisualChildrenCount
    //    {
    //        get
    //        {
    //            return visuals.Count;
    //        }
    //    }
    //    public void AddChild(Visual visual)
    //    {
    //        visuals.Add(visual);
    //        base.AddLogicalChild(visual);
    //        base.AddVisualChild(visual);
    //    }
    //    public void RemoveChild(Visual visual)
    //    {
    //        visuals.Remove(visual);
    //        base.RemoveLogicalChild(visual);
    //        base.RemoveVisualChild(visual);
    //    }
    //    public DrawingVisual GetVisual(Point pt)
    //    {
    //        if (VisualTreeHelper.HitTest(this, pt) == null) return null;
    //        HitTestResult hitresult = VisualTreeHelper.HitTest(this, pt);
    //        return hitresult.VisualHit as DrawingVisual;
    //    }
    //} 
    #endregion
    class MyPanel : Panel
    {
        public List<Visual> visuals = new List<Visual>();
        protected override Visual GetVisualChild(int index)
        {
            return visuals[index];
        }
        protected override int VisualChildrenCount
        {
            get
            {
                return visuals.Count;
            }
        }
        public void AddChild(Visual visual)
        {
            visuals.Add(visual);
            base.AddLogicalChild(visual);
            base.AddVisualChild(visual);
        }
        public void RemoveChild(Visual visual)
        {
            visuals.Remove(visual);
            base.RemoveLogicalChild(visual);
            base.RemoveVisualChild(visual);
        }
        public DrawingVisual GetVisual(Point pt)
        {
            if (VisualTreeHelper.HitTest(this, pt) == null) return null;
            HitTestResult hitresult = VisualTreeHelper.HitTest(this, pt);
            return hitresult.VisualHit as DrawingVisual;
        }

    }

}
