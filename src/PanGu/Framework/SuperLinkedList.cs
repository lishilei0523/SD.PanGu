/*
 * Licensed to the Apache Software Foundation (ASF) under one or more
 * contributor license agreements.  See the NOTICE file distributed with
 * this work for additional information regarding copyright ownership.
 * The ASF licenses this file to You under the Apache License, Version 2.0
 * (the "License"); you may not use this file except in compliance with
 * the License.  You may obtain a copy of the License at
 * 
 * http://www.apache.org/licenses/LICENSE-2.0
 * 
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Threading;

namespace PanGu.Framework
{
    [Serializable()]
    [ComVisible(false)]
    [DebuggerDisplay("Count = {Count}")]
    public class SuperLinkedList<T> : ICollection<T>, ICollection, ISerializable, IDeserializationCallback
    {
        // This SuperLinkedList is a doubly-Linked circular list.
        internal SuperLinkedListNode<T> head;
        internal int count;
        internal int version;
        private Object _syncRoot;

        private SerializationInfo siInfo; //A temporary variable which we need during deserialization. 

        // names for serialization
        const String VersionName = "Version";
        const String CountName = "Count";
        const String ValuesName = "Data";

        public SuperLinkedList()
        {
        }

        public SuperLinkedList(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("collection");
            }

            foreach (T item in collection)
            {
                this.AddLast(item);
            }
        }

        protected SuperLinkedList(SerializationInfo info, StreamingContext context)
        {
            this.siInfo = info;
        }

        public int Count
        {
            get { return this.count; }
        }

        public SuperLinkedListNode<T> First
        {
            get { return this.head; }
        }

        public SuperLinkedListNode<T> Last
        {
            get { return this.head == null ? null : this.head.prev; }
        }

        bool ICollection<T>.IsReadOnly
        {
            get { return false; }
        }

        void ICollection<T>.Add(T value)
        {
            this.AddLast(value);
        }

        public SuperLinkedListNode<T> AddAfter(SuperLinkedListNode<T> node, T value)
        {
            this.ValidateNode(node);
            SuperLinkedListNode<T> result = new SuperLinkedListNode<T>(node.list, value);
            this.InternalInsertNodeBefore(node.next, result);
            return result;
        }

        public void AddAfter(SuperLinkedListNode<T> node, SuperLinkedListNode<T> newNode)
        {
            this.ValidateNode(node);
            this.ValidateNewNode(newNode);
            this.InternalInsertNodeBefore(node.next, newNode);
            newNode.list = this;
        }

        public SuperLinkedListNode<T> AddAfter(SuperLinkedListNode<T> node, SuperLinkedList<T> newLinkedList)
        {
            if (newLinkedList.Count <= 0)
            {
                return node;
            }

            SuperLinkedListNode<T> cur = node;

            foreach (T t in newLinkedList)
            {
                cur = this.AddAfter(cur, t);
            }

            return cur;

            //SuperLinkedListNode<T> nodeNext = node.Next;
            //SuperLinkedListNode<T> newLast = newLinkedList.Last;

            //node.next = newLinkedList.First;
            //newLinkedList.First.prev = node;

            //if (nodeNext != null)
            //{
            //    newLast.next = nodeNext;
            //    nodeNext.prev = newLast;
            //}
            //else
            //{
            //    newLast.next = head;
            //    head.prev = newLast;
            //}

            //count += newLinkedList.Count;
        }

        public SuperLinkedListNode<T> AddBefore(SuperLinkedListNode<T> node, T value)
        {
            this.ValidateNode(node);
            SuperLinkedListNode<T> result = new SuperLinkedListNode<T>(node.list, value);
            this.InternalInsertNodeBefore(node, result);
            if (node == this.head)
            {
                this.head = result;
            }
            return result;
        }

        public void AddBefore(SuperLinkedListNode<T> node, SuperLinkedListNode<T> newNode)
        {
            this.ValidateNode(node);
            this.ValidateNewNode(newNode);
            this.InternalInsertNodeBefore(node, newNode);
            newNode.list = this;
            if (node == this.head)
            {
                this.head = newNode;
            }
        }

        public SuperLinkedListNode<T> AddFirst(T value)
        {
            SuperLinkedListNode<T> result = new SuperLinkedListNode<T>(this, value);
            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(result);
            }
            else
            {
                this.InternalInsertNodeBefore(this.head, result);
                this.head = result;
            }
            return result;
        }

        public void AddFirst(SuperLinkedListNode<T> node)
        {
            this.ValidateNewNode(node);

            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(node);
            }
            else
            {
                this.InternalInsertNodeBefore(this.head, node);
                this.head = node;
            }
            node.list = this;
        }

        public SuperLinkedListNode<T> AddLast(T value)
        {
            SuperLinkedListNode<T> result = new SuperLinkedListNode<T>(this, value);
            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(result);
            }
            else
            {
                this.InternalInsertNodeBefore(this.head, result);
            }
            return result;
        }

        public void AddLast(SuperLinkedListNode<T> node)
        {
            this.ValidateNewNode(node);

            if (this.head == null)
            {
                this.InternalInsertNodeToEmptyList(node);
            }
            else
            {
                this.InternalInsertNodeBefore(this.head, node);
            }
            node.list = this;
        }

        public void Clear()
        {
            SuperLinkedListNode<T> current = this.head;
            while (current != null)
            {
                SuperLinkedListNode<T> temp = current;
                current = current.Next;   // use Next the instead of "next", otherwise it will loop forever 
                temp.Invalidate();
            }

            this.head = null;
            this.count = 0;
            this.version++;
        }

        public bool Contains(T value)
        {
            return this.Find(value) != null;
        }

        public void CopyTo(T[] array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (index < 0 || index > array.Length)
            {
                throw new ArgumentOutOfRangeException("index", index.ToString());
            }

            if (array.Length - index < this.Count)
            {
                throw new ArgumentException("SR.Arg_InsufficientSpace");
            }

            SuperLinkedListNode<T> node = this.head;
            if (node != null)
            {
                do
                {
                    array[index++] = node.item;
                    node = node.next;
                } while (node != this.head);
            }
        }

        public SuperLinkedListNode<T> Find(T value)
        {
            SuperLinkedListNode<T> node = this.head;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (node != null)
            {
                if (value != null)
                {
                    do
                    {
                        if (c.Equals(node.item, value))
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != this.head);
                }
                else
                {
                    do
                    {
                        if (node.item == null)
                        {
                            return node;
                        }
                        node = node.next;
                    } while (node != this.head);
                }
            }
            return null;
        }

        public SuperLinkedListNode<T> FindLast(T value)
        {
            if (this.head == null) return null;

            SuperLinkedListNode<T> last = this.head.prev;
            SuperLinkedListNode<T> node = last;
            EqualityComparer<T> c = EqualityComparer<T>.Default;
            if (node != null)
            {
                if (value != null)
                {
                    do
                    {
                        if (c.Equals(node.item, value))
                        {
                            return node;
                        }

                        node = node.prev;
                    } while (node != last);
                }
                else
                {
                    do
                    {
                        if (node.item == null)
                        {
                            return node;
                        }
                        node = node.prev;
                    } while (node != last);
                }
            }
            return null;
        }

        public Enumerator GetEnumerator()
        {
            return new Enumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public bool Remove(T value)
        {
            SuperLinkedListNode<T> node = this.Find(value);
            if (node != null)
            {
                this.InternalRemoveNode(node);
                return true;
            }
            return false;
        }

        public void Remove(SuperLinkedListNode<T> node)
        {
            this.ValidateNode(node);
            this.InternalRemoveNode(node);
        }

        public void RemoveFirst()
        {
            if (this.head == null) { throw new InvalidOperationException("LinkedListEmpty"); }
            this.InternalRemoveNode(this.head);
        }

        public void RemoveLast()
        {
            if (this.head == null) { throw new InvalidOperationException("SR.LinkedListEmpty"); }
            this.InternalRemoveNode(this.head.prev);
        }

        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public virtual void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            // Customized serialization for SuperLinkedList.
            // We need to do this because it will be too expensive to Serialize each node. 
            // This will give us the flexiblility to change internal implementation freely in future.
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            info.AddValue(VersionName, this.version);
            info.AddValue(CountName, this.count); //This is the length of the bucket array. 
            if (this.count != 0)
            {
                T[] array = new T[this.Count];
                this.CopyTo(array, 0);
                info.AddValue(ValuesName, array, typeof(T[]));
            }
        }

        public virtual void OnDeserialization(Object sender)
        {
            if (this.siInfo == null)
            {
                return; //Somebody had a dependency on this Dictionary and fixed us up before the ObjectManager got to it. 
            }

            int realVersion = this.siInfo.GetInt32(VersionName);
            int count = this.siInfo.GetInt32(CountName);

            if (count != 0)
            {
                T[] array = (T[])this.siInfo.GetValue(ValuesName, typeof(T[]));

                if (array == null)
                {
                    throw new SerializationException("SR.Serialization_MissingValues");
                }
                for (int i = 0; i < array.Length; i++)
                {
                    this.AddLast(array[i]);
                }
            }
            else
            {
                this.head = null;
            }

            this.version = realVersion;
            this.siInfo = null;
        }


        private void InternalInsertNodeBefore(SuperLinkedListNode<T> node, SuperLinkedListNode<T> newNode)
        {
            newNode.next = node;
            newNode.prev = node.prev;
            node.prev.next = newNode;
            node.prev = newNode;
            this.version++;
            this.count++;
        }

        private void InternalInsertNodeToEmptyList(SuperLinkedListNode<T> newNode)
        {
            Debug.Assert(this.head == null && this.count == 0, "SuperLinkedList must be empty when this method is called!");
            newNode.next = newNode;
            newNode.prev = newNode;
            this.head = newNode;
            this.version++;
            this.count++;
        }

        internal void InternalRemoveNode(SuperLinkedListNode<T> node)
        {
            Debug.Assert(node.list == this, "Deleting the node from another list!");
            Debug.Assert(this.head != null, "This method shouldn't be called on empty list!");
            if (node.next == node)
            {
                Debug.Assert(this.count == 1 && this.head == node, "this should only be true for a list with only one node");
                this.head = null;
            }
            else
            {
                node.next.prev = node.prev;
                node.prev.next = node.next;
                if (this.head == node)
                {
                    this.head = node.next;
                }
            }
            node.Invalidate();
            this.count--;
            this.version++;
        }

        internal void ValidateNewNode(SuperLinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (node.list != null)
            {
                throw new InvalidOperationException("SR.LinkedListNodeIsAttached");
            }
        }


        internal void ValidateNode(SuperLinkedListNode<T> node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            if (node.list != this)
            {
                throw new InvalidOperationException("SR.ExternalLinkedListNode");
            }
        }

        bool ICollection.IsSynchronized
        {
            get { return false; }
        }

        object ICollection.SyncRoot
        {
            get
            {
                if (this._syncRoot == null)
                {
                    Interlocked.CompareExchange(ref this._syncRoot, new Object(), null);
                }
                return this._syncRoot;
            }
        }

        void ICollection.CopyTo(Array array, int index)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }

            if (array.Rank != 1)
            {
                throw new ArgumentException("SR.Arg_MultiRank");
            }

            if (array.GetLowerBound(0) != 0)
            {
                throw new ArgumentException("SR.Arg_NonZeroLowerBound");
            }

            if (index < 0)
            {
                throw new ArgumentOutOfRangeException("index", index.ToString());
            }

            if (array.Length - index < this.Count)
            {
                throw new ArgumentException("SR.Arg_InsufficientSpace");
            }

            T[] tArray = array as T[];
            if (tArray != null)
            {
                this.CopyTo(tArray, index);
            }
            else
            {
                //
                // Catch the obvious case assignment will fail. 
                // We can found all possible problems by doing the check though.
                // For example, if the element type of the Array is derived from T, 
                // we can't figure out if we can successfully copy the element beforehand. 
                //
                Type targetType = array.GetType().GetElementType();
                Type sourceType = typeof(T);
                if (!(targetType.IsAssignableFrom(sourceType) || sourceType.IsAssignableFrom(targetType)))
                {
                    throw new ArgumentException("SR.Invalid_Array_Type");
                }

                object[] objects = array as object[];
                if (objects == null)
                {
                    throw new ArgumentException("SR.Invalid_Array_Type");
                }
                SuperLinkedListNode<T> node = this.head;
                try
                {
                    if (node != null)
                    {
                        do
                        {
                            objects[index++] = node.item;
                            node = node.next;
                        } while (node != this.head);
                    }
                }
                catch (ArrayTypeMismatchException)
                {
                    throw new ArgumentException("SR.Invalid_Array_Type");
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }


        [Serializable()]
        public struct Enumerator : IEnumerator<T>, IEnumerator, ISerializable, IDeserializationCallback
        {
            private SuperLinkedList<T> list;
            private SuperLinkedListNode<T> node;
            private int version;
            private T current;
            private int index;
            private SerializationInfo siInfo; //A temporary variable which we need during deserialization.

            const string LinkedListName = "LinkedList";
            const string CurrentValueName = "Current";
            const string VersionName = "Version";
            const string IndexName = "Index";

            internal Enumerator(SuperLinkedList<T> list)
            {
                this.list = list;
                this.version = list.version;
                this.node = list.head;
                this.current = default(T);
                this.index = 0;
                this.siInfo = null;
            }

            internal Enumerator(SerializationInfo info, StreamingContext context)
            {
                this.siInfo = info;
                this.list = null;
                this.version = 0;
                this.node = null;
                this.current = default(T);
                this.index = 0;
            }

            public T Current
            {
                get { return this.current; }
            }

            object IEnumerator.Current
            {
                get
                {
                    if (this.index == 0 || (this.index == this.list.Count + 1))
                    {
                        throw new InvalidOperationException("ExceptionResource.InvalidOperation_EnumOpCantHappen");
                    }

                    return this.current;
                }
            }

            public bool MoveNext()
            {
                if (this.version != this.list.version)
                {
                    throw new InvalidOperationException("SR.InvalidOperation_EnumFailedVersion");
                }

                if (this.node == null)
                {
                    this.index = this.list.Count + 1;
                    return false;
                }

                ++this.index;
                this.current = this.node.item;
                this.node = this.node.next;
                if (this.node == this.list.head)
                {
                    this.node = null;
                }
                return true;
            }

            void IEnumerator.Reset()
            {
                if (this.version != this.list.version)
                {
                    throw new InvalidOperationException("SR.InvalidOperation_EnumFailedVersion");
                }

                this.current = default(T);
                this.node = this.list.head;
                this.index = 0;
            }

            public void Dispose()
            {
            }

            void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
            {
                if (info == null)
                {
                    throw new ArgumentNullException("info");
                }

                info.AddValue(LinkedListName, this.list);
                info.AddValue(VersionName, this.version);
                info.AddValue(CurrentValueName, this.current);
                info.AddValue(IndexName, this.index);
            }

            void IDeserializationCallback.OnDeserialization(Object sender)
            {
                if (this.list != null)
                {
                    return; //Somebody had a dependency on this Dictionary and fixed us up before the ObjectManager got to it. 
                }

                if (this.siInfo == null)
                {
                    throw new SerializationException("SR.Serialization_InvalidOnDeser");
                }

                this.list = (SuperLinkedList<T>)this.siInfo.GetValue(LinkedListName, typeof(SuperLinkedList<T>));
                this.version = this.siInfo.GetInt32(VersionName);
                this.current = (T)this.siInfo.GetValue(CurrentValueName, typeof(T));
                this.index = this.siInfo.GetInt32(IndexName);

                if (this.list.siInfo != null)
                {
                    this.list.OnDeserialization(sender);
                }

                if (this.index == this.list.Count + 1)
                {  // end of enumeration
                    this.node = null;
                }
                else
                {
                    this.node = this.list.First;
                    // We don't care if we can point to the correct node if the LinkedList was changed 
                    // MoveNext will throw upon next call and Current has the correct value.
                    if (this.node != null && this.index != 0)
                    {
                        for (int i = 0; i < this.index; i++)
                        {
                            this.node = this.node.next;
                        }
                        if (this.node == this.list.First)
                        {
                            this.node = null;
                        }
                    }
                }
                this.siInfo = null;
            }
        }

    }

    // Note following class is not serializable since we customized the serialization of LinkedList. 
    [ComVisible(false)]
    public sealed class SuperLinkedListNode<T>
    {
        internal SuperLinkedList<T> list;
        internal SuperLinkedListNode<T> next;
        internal SuperLinkedListNode<T> prev;
        internal T item;

        public SuperLinkedListNode(T value)
        {
            this.item = value;
        }

        internal SuperLinkedListNode(SuperLinkedList<T> list, T value)
        {
            this.list = list;
            this.item = value;
        }

        public SuperLinkedList<T> List
        {
            get { return this.list; }
        }

        public SuperLinkedListNode<T> Next
        {
            get { return this.next == null || this.next == this.list.head ? null : this.next; }
        }

        public SuperLinkedListNode<T> Previous
        {
            get { return this.prev == null || this == this.list.head ? null : this.prev; }
        }

        public T Value
        {
            get { return this.item; }
            set { this.item = value; }
        }

        internal void Invalidate()
        {
            this.list = null;
            this.next = null;
            this.prev = null;
        }
    }
}

