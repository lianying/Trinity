﻿using Trinity.Framework.Objects.Enums;
using Zeta.Common;
using Zeta.Game;
using Zeta.Game.Internals;

namespace Trinity.Framework.Objects.Memory
{
    public class Marker : MemoryWrapper
    {
        public string Name => SnoManager.StringListHelper.GetStringListValue((SnoStringListType)StringListSnoId, NameHash);
        public float Distance => ZetaDia.Me.Position.Distance(Position);
        public int Id => ReadOffset<int>(0x4);
        public Vector3 Position => ReadOffset<Vector3>(0x8);
        public int WorldId => ReadOffset<int>(0x14);
        public int MinimapTextureId => ReadOffset<int>(0x18);
        public WorldMarkerType MarkerType => (WorldMarkerType)MinimapTextureId;
        public int NameHash => ReadOffset<int>(0x20);
        public int StringListSnoId => ReadOffset<int>(0x24);

        static public explicit operator Marker(MinimapMarker marker)
        {
            return Create<Marker>(marker.BaseAddress);
        }

        public override string ToString()
        {
            return $"{Name}, Distance={Distance} TextureId={MinimapTextureId}";
        }
    }
}