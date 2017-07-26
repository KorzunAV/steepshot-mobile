﻿using Android.Support.V4.App;

namespace Steepshot
{
	public class HostFragment : BackStackFragment
	{
		private Fragment fragment;

		public override Android.Views.View OnCreateView(Android.Views.LayoutInflater inflater, Android.Views.ViewGroup container, Android.OS.Bundle savedInstanceState)
		{
			base.OnCreateView(inflater, container, savedInstanceState);
			var view = inflater.Inflate(Resource.Layout.HostLayout, container, false);
			if (fragment != null)
			{
				ReplaceFragment(fragment, false);
			}
			return view;
		}

		public void ReplaceFragment(Fragment fragment, bool addToBackstack)
		{
			if (addToBackstack)
			{
				ChildFragmentManager.BeginTransaction().Replace(Resource.Id.child_fragment_container, fragment).AddToBackStack(null).Commit();
			}
			else
			{
				ChildFragmentManager.BeginTransaction().Replace(Resource.Id.child_fragment_container, fragment).Commit();
			}
		}

		public static HostFragment NewInstance(Fragment fragment)
		{
			HostFragment hostFragment = new HostFragment();
			hostFragment.fragment = fragment;
			return hostFragment;
		}

		public override bool UserVisibleHint
		{
			get
			{
				return base.UserVisibleHint;
			}
			set
			{
				((BaseFragment)fragment).CustomUserVisibleHint = value;
				base.UserVisibleHint = value;
			}
		}
	}
}