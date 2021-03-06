# SyncFoundation
## Introduction
SyncFoundation is a framework that can be used to add both client-server and peer-to-peer synchronization capabilities to an application.  It is heavily based on the ideas in [Microsoft's Sync Framework](http://msdn.microsoft.com/sync).  SyncFoundation uses JSON to encode items and HTTP POSTs to communicate between endpoints.  Authentication is handled via a digest scheme similar to the WS-Security UsernameToken.
## Overview
Each synchronization endpoint is called a Replica.  Each Replica has a unique ReplicaId and a monotonically increasing numeric TickCount.  A Replica’s Knowledge is all the changes it is aware of.  This is implemented a list of ReplicaIds with associated TickCounts.

Applications that want to support synchronization are required to track a certain amount of metadata that describes when and where the item was changed. This metadata is composed of two versions: a Created version and a Modified version. A version is composed of two components: a ReplicaId that identifies where the version comes from and a TickCount indicating when the version comes from. The Created version is the same as the Modified version when the item is initially created. Subsequent updates to the item update the Modified version.  

Applications also need to track when items are deleted.  This tracking is generally accomplished via Tombstones.  Tombstones contain the same metadata as items: a Created version and a Modified version.  For a tombstone, the Modified version indicates when and where the item was deleted.  

SyncFoundation works on a pull then push model.  This allows the source to find and resolve any conflicts that are encountered before they are pushed to the destination.  Applications should prevent any updates while a synchronization is occurring.      
