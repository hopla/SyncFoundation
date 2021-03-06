﻿using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace SyncFoundation.Core.Interfaces
{
    public interface ISyncableStore : IDisposable
    {
        IEnumerable<string> GetItemTypes();

        long IncrementLocalRepilcaTickCount();
        string GetLocalReplicaId();

        IEnumerable<IReplicaInfo> GenerateLocalKnowledge();
        IEnumerable<ISyncableItemInfo> LocateChangedItems(IEnumerable<IReplicaInfo> remoteKnowledge);

        ISyncableItemInfo LocateCurrentItemInfo(ISyncableItemInfo source);

        void BuildItemData(ISyncableItemInfo itemInfo, JObject itemData);

        void BeginChanges();

        void SaveItemData(ISyncableItemInfo itemInfo, JObject itemData);
        void DeleteItem(ISyncableItemInfo itemInfo);
        void UpdateLocalKnowledge(IEnumerable<IReplicaInfo> remoteKnowledge);

        void AcceptChanges();
        void RejectChanges();

        DuplicateStatus GetDuplicateStatus(string itemType, JObject localItemData, JObject remoteItemData);
    }
}
