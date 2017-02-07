﻿namespace Lucene.Net.Facet.Taxonomy.WriterCache
{
    /*
	 * Licensed to the Apache Software Foundation (ASF) under one or more
	 * contributor license agreements.  See the NOTICE file distributed with
	 * this work for additional information regarding copyright ownership.
	 * The ASF licenses this file to You under the Apache License, Version 2.0
	 * (the "License"); you may not use this file except in compliance with
	 * the License.  You may obtain a copy of the License at
	 *
	 *     http://www.apache.org/licenses/LICENSE-2.0
	 *
	 * Unless required by applicable law or agreed to in writing, software
	 * distributed under the License is distributed on an "AS IS" BASIS,
	 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
	 * See the License for the specific language governing permissions and
	 * limitations under the License.
	 */

    /// <summary>
    /// An an LRU cache of mapping from name to int.
    /// Used to cache Ordinals of category paths.
    /// It uses as key, hash of the path instead of the path.
    /// This way the cache takes less RAM, but correctness depends on
    /// assuming no collisions. 
    /// 
    /// @lucene.experimental
    /// </summary>
    public class NameHashIntCacheLRU : NameIntCacheLRU
    {
        internal NameHashIntCacheLRU(int maxCacheSize)
            : base(maxCacheSize)
        {
        }

        internal override object Key(FacetLabel name)
        {
            return new long?(name.Int64HashCode());
        }

        internal override object Key(FacetLabel name, int prefixLen)
        {
            return new long?(name.Subpath(prefixLen).Int64HashCode());
        }
    }
}