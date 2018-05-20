using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AbsenzenVerwaltungsTool.Models
{
    [MetadataType(typeof(AbsenzMetadata))]
    public partial class Absenz
    {
    }

    [MetadataType(typeof(ModulMetadata))]
    public partial class Modul
    {
    }

    [MetadataType(typeof(KlasseMetadata))]
    public partial class Klasse
    {
    }

    [MetadataType(typeof(LehrerMetadata))]
    public partial class Lehrer
    {
    }

    [MetadataType(typeof(SchuelerMetadata))]
    public partial class Schueler
    {
    }
}