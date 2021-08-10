using System;

namespace carros_xamarin_clean.Core.Domain.Entity
{
    public class CarViewFlyoutMenuItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public Action TargetAction { get; set; }
    }
}
