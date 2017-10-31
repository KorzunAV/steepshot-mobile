﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Steepshot.Core.Models.Common;
using Steepshot.Core.Models.Requests;

namespace Steepshot.Core.Presenters
{
    public class BasePostPresenter : ListPresenter<Post>
    {
        public void RemovePostsAt(int index)
        {
            lock (Items)
                Items.RemoveAt(index);
        }

        public int IndexOf(Func<Post, bool> func)
        {
            lock (Items)
            {
                for (var i = 0; i < Items.Count; i++)
                    if (func(Items[i]))
                        return i;
            }
            return -1;
        }

        public async Task<List<string>> TryVote(Func<Post, bool> func)
        {
            Post post;
            lock (Items)
                post = Items.FirstOrDefault(func);

            if (post == null)
                return null;

            return await TryRunTask(Vote, OnDisposeCts.Token, post);
        }

        public async Task<List<string>> TryVote(Post post)
        {
            if (post == null)
                return null;

            return await TryRunTask(Vote, OnDisposeCts.Token, post);
        }

        public async Task<List<string>> TryVote(int position)
        {
            Post post;
            lock (Items)
                post = Items[position];
            if (post == null)
                return null;
            return await TryRunTask(Vote, OnDisposeCts.Token, post);
        }

        private async Task<List<string>> Vote(CancellationToken ct, Post post)
        {
            var request = new VoteRequest(User.UserInfo, (bool)post.Vote ? VoteType.Down : VoteType.Up, post.Url);
            post.WasVoted = (bool)post.Vote;
            post.Vote = null;
            var response = await Api.Vote(request, ct);
            if (response == null)
                return null;

            if (response.Success)
            {
                post.Vote = !post.WasVoted;
                post.Flag = false;
                post.TotalPayoutReward = response.Result.NewTotalPayoutReward;
                post.NetVotes = response.Result.NetVotes;
            }
            else
                post.Vote = post.WasVoted;

            return response.Errors;
        }

        public async Task<List<string>> TryFlag(Func<Post, bool> func)
        {
            Post post;
            lock (Items)
                post = Items.FirstOrDefault(func);
            if (post == null)
                return null;
            return await TryRunTask(Flag, OnDisposeCts.Token, post);
        }

        public async Task<List<string>> TryFlag(int position)
        {
            Post post;
            lock (Items)
                post = Items[position];
            if (post == null)
                return null;
            return await TryRunTask(Flag, OnDisposeCts.Token, post);
        }

        private async Task<List<string>> Flag(CancellationToken ct, Post post)
        {
            var request = new VoteRequest(User.UserInfo, post.Flag ? VoteType.Down : VoteType.Flag, post.Url);
            var response = await Api.Vote(request, ct);
            if (response == null)
                return null;

            if (response.Success)
            {
                post.Flag = !post.Flag;
                post.Vote = false;
                post.TotalPayoutReward = response.Result.NewTotalPayoutReward;
                post.NetVotes = response.Result.NetVotes;
            }
            return response.Errors;
        }
    }
}