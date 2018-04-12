﻿using System;
using NUnit.Framework;
using Steepshot.Core.Localization;
using Steepshot.Core.Utils;

namespace Steepshot.Core.Tests.Localization
{
    [TestFixture]
    public class MessageTest : BaseTests
    {
        public LocalizationManager Lm => AppSettings.LocalizationManager;

        [Test]
        [TestCase(nameof(LocalizationKeys.WrongPrivatePostingKey))]
        [TestCase(nameof(LocalizationKeys.WrongPrivateActimeKey))]
        [TestCase(nameof(LocalizationKeys.EmptyResponseContent))]
        [TestCase(nameof(LocalizationKeys.EnableConnectToBlockchain))]
        [TestCase(nameof(LocalizationKeys.ServeUnexpectedError))]
        [TestCase(nameof(LocalizationKeys.UnknownError))]
        [TestCase(nameof(LocalizationKeys.EmptyTitleField))]
        [TestCase(nameof(LocalizationKeys.EmptyFileField))]
        [TestCase(nameof(LocalizationKeys.EmptyVerifyTransaction))]
        [TestCase(nameof(LocalizationKeys.EmptyUrlField))]
        [TestCase(nameof(LocalizationKeys.EmptyUsernameField))]
        [TestCase(nameof(LocalizationKeys.EmptyLogin))]
        [TestCase(nameof(LocalizationKeys.EmptyPostingKey))]
        [TestCase(nameof(LocalizationKeys.EmptyActiveKey))]
        [TestCase(nameof(LocalizationKeys.EmptyCategory))]
        [TestCase(nameof(LocalizationKeys.PhotoProcessingError))]
        [TestCase(nameof(LocalizationKeys.ErrorCameraScale))]
        [TestCase(nameof(LocalizationKeys.ErrorCameraZoom))]
        [TestCase(nameof(LocalizationKeys.InternetUnavailable))]
        [TestCase(nameof(LocalizationKeys.UnexpectedError))]
        [TestCase(nameof(LocalizationKeys.CameraSettingError))]
        [TestCase(nameof(LocalizationKeys.TagLimitError))]
        [TestCase(nameof(LocalizationKeys.UnsupportedMime))]
        [TestCase(nameof(LocalizationKeys.UnexpectedProfileData))]
        [TestCase(nameof(LocalizationKeys.PostFirstComment))]
        [TestCase(nameof(LocalizationKeys.ScanQRCode))]
        [TestCase(nameof(LocalizationKeys.Comments))]
        [TestCase(nameof(LocalizationKeys.PostSettings))]
        [TestCase(nameof(LocalizationKeys.CameraHoldUp))]
        [TestCase(nameof(LocalizationKeys.WaitforScan))]
        [TestCase(nameof(LocalizationKeys.Likes))]
        [TestCase(nameof(LocalizationKeys.Like))]
        [TestCase(nameof(LocalizationKeys.Flags))]
        [TestCase(nameof(LocalizationKeys.Flag))]
        [TestCase(nameof(LocalizationKeys.Follow))]
        [TestCase(nameof(LocalizationKeys.Unfollow))]
        [TestCase(nameof(LocalizationKeys.Ok))]
        [TestCase(nameof(LocalizationKeys.TryAgain))]
        [TestCase(nameof(LocalizationKeys.Forget))]
        [TestCase(nameof(LocalizationKeys.Voters))]
        [TestCase(nameof(LocalizationKeys.FlagVoters))]
        [TestCase(nameof(LocalizationKeys.ViewComments))]
        [TestCase(nameof(LocalizationKeys.FlagPhoto))]
        [TestCase(nameof(LocalizationKeys.HidePhoto))]
        [TestCase(nameof(LocalizationKeys.Hot))]
        [TestCase(nameof(LocalizationKeys.New))]
        [TestCase(nameof(LocalizationKeys.Top))]
        [TestCase(nameof(LocalizationKeys.Clear))]
        [TestCase(nameof(LocalizationKeys.SeeComment))]
        [TestCase(nameof(LocalizationKeys.Photos))]
        [TestCase(nameof(LocalizationKeys.Following))]
        [TestCase(nameof(LocalizationKeys.Followers))]
        [TestCase(nameof(LocalizationKeys.Reply))]
        [TestCase(nameof(LocalizationKeys.AcceptToS))]
        [TestCase(nameof(LocalizationKeys.YourAccountName))]
        [TestCase(nameof(LocalizationKeys.NextStep))]
        [TestCase(nameof(LocalizationKeys.Account))]
        [TestCase(nameof(LocalizationKeys.NsfwShow))]
        [TestCase(nameof(LocalizationKeys.Nsfw))]
        [TestCase(nameof(LocalizationKeys.NsfwContent))]
        [TestCase(nameof(LocalizationKeys.NsfwContentExplanation))]
        [TestCase(nameof(LocalizationKeys.LowRated))]
        [TestCase(nameof(LocalizationKeys.LowRatedContent))]
        [TestCase(nameof(LocalizationKeys.LowRatedContentExplanation))]
        [TestCase(nameof(LocalizationKeys.FlagMessage))]
        //[TestCase(nameof(LocalizationKeys.FlagSubMessage))]
        [TestCase(nameof(LocalizationKeys.DeleteAlertTitle))]
        [TestCase(nameof(LocalizationKeys.DeleteAlertMessage))]
        [TestCase(nameof(LocalizationKeys.PowerOfLike))]
        [TestCase(nameof(LocalizationKeys.TitleForAcceptToS))]
        [TestCase(nameof(LocalizationKeys.PostDelay))]
        [TestCase(nameof(LocalizationKeys.SignInButtonText))]
        [TestCase(nameof(LocalizationKeys.CreateButtonText))]
        [TestCase(nameof(LocalizationKeys.EnterAccountText))]
        [TestCase(nameof(LocalizationKeys.PasswordViewTitleText))]
        [TestCase(nameof(LocalizationKeys.PublishButtonText))]
        [TestCase(nameof(LocalizationKeys.AppSettingsTitle))]
        [TestCase(nameof(LocalizationKeys.AddAccountText))]
        [TestCase(nameof(LocalizationKeys.PeopleText))]
        [TestCase(nameof(LocalizationKeys.TapToSearch))]
        [TestCase(nameof(LocalizationKeys.SearchHint))]
        [TestCase(nameof(LocalizationKeys.Tag))]
        [TestCase(nameof(LocalizationKeys.Users))]
        [TestCase(nameof(LocalizationKeys.YearsAgo))]
        [TestCase(nameof(LocalizationKeys.MonthAgo))]
        [TestCase(nameof(LocalizationKeys.DaysAgo))]
        [TestCase(nameof(LocalizationKeys.DayAgo))]
        [TestCase(nameof(LocalizationKeys.HrsAgo))]
        [TestCase(nameof(LocalizationKeys.HrAgo))]
        [TestCase(nameof(LocalizationKeys.MinAgo))]
        [TestCase(nameof(LocalizationKeys.SecAgo))]
        [TestCase(nameof(LocalizationKeys.CreateFirstPostText))]
        [TestCase(nameof(LocalizationKeys.Copied))]
        [TestCase(nameof(LocalizationKeys.PostLink))]
        [TestCase(nameof(LocalizationKeys.ShowMoreString))]
        [TestCase(nameof(LocalizationKeys.SignIn))]
        [TestCase(nameof(LocalizationKeys.FlagPost))]
        [TestCase(nameof(LocalizationKeys.UnFlagPost))]
        [TestCase(nameof(LocalizationKeys.FlagComment))]
        [TestCase(nameof(LocalizationKeys.HideComment))]
        [TestCase(nameof(LocalizationKeys.EditComment))]
        [TestCase(nameof(LocalizationKeys.DeleteComment))]
        [TestCase(nameof(LocalizationKeys.UnFlagComment))]
        [TestCase(nameof(LocalizationKeys.HidePost))]
        [TestCase(nameof(LocalizationKeys.EditPost))]
        [TestCase(nameof(LocalizationKeys.DeletePost))]
        [TestCase(nameof(LocalizationKeys.CopyLink))]
        [TestCase(nameof(LocalizationKeys.Cancel))]
        [TestCase(nameof(LocalizationKeys.Retry))]
        [TestCase(nameof(LocalizationKeys.Delete))]
        [TestCase(nameof(LocalizationKeys.PutYourComment))]
        [TestCase(nameof(LocalizationKeys.AppVersion2))]
        [TestCase(nameof(LocalizationKeys.QueryMinLength))]
        [TestCase(nameof(LocalizationKeys.EnterPostTitle))]
        [TestCase(nameof(LocalizationKeys.EnterPostDescription))]
        [TestCase(nameof(LocalizationKeys.AddHashtag))]
        [TestCase(nameof(LocalizationKeys.MyProfile))]
        [TestCase(nameof(LocalizationKeys.AccountBalance))]
        [TestCase(nameof(LocalizationKeys.ShowNsfw))]
        [TestCase(nameof(LocalizationKeys.ShowLowRated))]
        [TestCase(nameof(LocalizationKeys.Guidelines))]
        [TestCase(nameof(LocalizationKeys.ToS))]
        [TestCase(nameof(LocalizationKeys.Sharepost))]
        [TestCase(nameof(LocalizationKeys.CheckPermission))]
        [TestCase(nameof(LocalizationKeys.SetupMail))]
        [TestCase(nameof(LocalizationKeys.EmptyQuery))]
        [TestCase("<h1>Server Error (500)</h1>")]
        [TestCase("Wrong identifier")]
        [TestCase("The submitted file is empty")]
        [TestCase("13 N5boost16exception_detail10clone_implINS0_19error_info_injectorISt12out_of_rangeEEEE: unknown key")]
        [TestCase("Category used for offset was not found")]
        [TestCase("4100000 plugin_exception: plugin exception: The comment is archived")]
        [TestCase("4100000 plugin_exception: plugin exception Account: steem bandwidth limit exceeded. Please wait to transact or power up STEEM")]
        [TestCase("4100000 plugin_exception: plugin exception: Account: ${account} bandwidth limit exceeded. Please wait to transact or power up STEEM")]
        [TestCase("3030000 tx_missing_posting_auth: missing required posting authority")]
        [TestCase("Size of the uploaded file is too big. Max size: 10 MB")]
        [TestCase("10 assert_exception: Assert Exception: itr->vote_percent != o.weight: You have already voted in a similar way")]
        [TestCase(@"<html><head><title>413 Request Entity Too Large</title></head>")]
        public void GetText(string key)
        {
            Console.Write($"{key} => ");
            Assert.IsTrue(Lm.ContainsKey(key));
            var text = Lm.GetText(key);
            Console.WriteLine(text);
            Assert.IsFalse(string.IsNullOrEmpty(text));
        }
    }
}
