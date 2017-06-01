﻿using System;
using System.Collections.Generic;
using System.Net;
using Foundation;
using Sweetshot.Library.Models.Responses;
using UIKit;

namespace Steepshot.iOS
{
	public delegate void HeaderTappedHandler(string username);
	public delegate void ImagePreviewHandler(UIImage image, string imageUrl);
	public delegate void VoteEventHandler<T>(bool vote, string postUri, Action<string, T> success);

    public partial class FeedTableViewCell : UITableViewCell
    {
        public static readonly NSString Key = new NSString("FeedTableViewCell");
        public static readonly UINib Nib;

        private bool isButtonBinded = false;
        private List<WebClient> webClients = new List<WebClient>();
		public event VoteEventHandler<VoteResponse> Voted;
		public event HeaderTappedHandler GoToProfile;
		public event HeaderTappedHandler GoToComments;
		public event ImagePreviewHandler ImagePreview;
		private Post _currentPost;

        public bool IsVotedSet
        {
            get
			{
                return Voted != null;
            }
        }

		public bool IsGoToProfileSet
		{
			get
			{
				return GoToProfile != null;
			}
		}

		public bool IsGoToCommentsSet
		{
			get
			{
				return GoToComments != null;
			}
		}

		public bool IsImagePreviewSet
		{
			get
			{
				return ImagePreview != null;
			}
		}

        static FeedTableViewCell()
        {
            Nib = UINib.FromName("FeedTableViewCell", NSBundle.MainBundle);
        }

        protected FeedTableViewCell(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void LayoutSubviews()
        {
            avatarImage.Layer.CornerRadius = avatarImage.Frame.Size.Width / 2;
            base.LayoutSubviews();
        }

        public void UpdateCell(Post post)
        {
			_currentPost = post;
            cellText.Text = post.Author;
			rewards.Text = $"{Constants.Currency}{post.TotalPayoutReward.ToString()}";
            netVotes.Text = $"{post.NetVotes.ToString()} likes";
            likeButton.Selected = post.Vote;
            var nicknameAttribute = new UIStringAttributes
            {
                Font = UIFont.BoldSystemFontOfSize(commentText.Font.PointSize)
            };
            NSMutableAttributedString at = new NSMutableAttributedString();
            at.Append(new NSAttributedString(post.Author, nicknameAttribute));
            at.Append(new NSAttributedString(" "));
            at.Append(new NSAttributedString(post.Title));
            commentText.AttributedText = at;
            var buttonTitle = post.Children == 0 ? "Post first comment" : $"View {post.Children} comments";
            viewCommentButton.SetTitle(buttonTitle, UIControlState.Normal);
            likeButton.Enabled = true;

			if (!isButtonBinded)
			{
				UITapGestureRecognizer tap = new UITapGestureRecognizer(() =>
				{
					ImagePreview(bodyImage.Image, "");
				});
				bodyImage.AddGestureRecognizer(tap);
			}

			if (!isButtonBinded)
			{
				UITapGestureRecognizer imageTap = new UITapGestureRecognizer(() =>
				{
					GoToProfile(_currentPost.Author);
				});
				UITapGestureRecognizer textTap = new UITapGestureRecognizer(() =>
				{
					GoToProfile(_currentPost.Author);
				});
				avatarImage.AddGestureRecognizer(imageTap);
				cellText.AddGestureRecognizer(textTap);
			}

			if (!isButtonBinded)
			{
				UITapGestureRecognizer tap = new UITapGestureRecognizer(() =>
				{
					GoToComments(_currentPost.Url);
				});
				commentView.AddGestureRecognizer(tap);
			}

            if (!isButtonBinded)
            {
                likeButton.TouchDown += LikeTap;
                isButtonBinded = true;
            }

            foreach (var webClient in webClients)
            {
                if (webClient != null)
                {
                    webClient.CancelAsync();
                    webClient.Dispose();
                }
            }

			ImageDownloader.Download(post.Avatar, avatarImage, UIImage.FromBundle("ic_user_placeholder"), webClients);
			ImageDownloader.Download(post.Body, bodyImage, UIImage.FromBundle("ic_photo_holder"), webClients);
        }

        private void LikeTap(object sender, EventArgs e)
        {
            likeButton.Enabled = false;
            Voted(!likeButton.Selected, _currentPost.Url, (url, post) =>
            {
				if (url == _currentPost.Url)
                {
					likeButton.Selected = post.IsVoted;
                    likeButton.Enabled = true;
					rewards.Text = $"{Constants.Currency}{post.NewTotalPayoutReward.ToString()}";

					_currentPost.NetVotes++;
					netVotes.Text = $"{_currentPost.NetVotes.ToString()} likes";
                }
            });
        }
    }
}
