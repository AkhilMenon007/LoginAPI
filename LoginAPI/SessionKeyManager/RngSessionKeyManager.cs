﻿using System;
using System.Collections.Generic;

namespace SessionKeyManager
{
    public class RngSessionKeyManager : ISessionKeyManager
    {
        private readonly HashSet<string> SessionKeys;
        private readonly Stack<string> FreeKeys;
        readonly Random random;

        public RngSessionKeyManager() 
        {
            SessionKeys = new HashSet<string>();
            FreeKeys = new Stack<string>();
            random = new Random(DateTime.Now.Millisecond);
        }

        public string GenerateNewSessionKey(string userID)
        {
            if (FreeKeys.Count == 0)
            {
                int r = random.Next(1, int.MaxValue);
                while (SessionKeys.Contains(r.ToString()))
                    r = random.Next(1, int.MaxValue);
                FreeKeys.Push(r.ToString());
            }
            SessionKeys.Add(FreeKeys.Peek());
            return FreeKeys.Pop();
        }
        public void ReleaseSessionKey(string key)
        {
            if (SessionKeys.Remove(key))
            {
                FreeKeys.Push(key);
            }
        }
    }
}
