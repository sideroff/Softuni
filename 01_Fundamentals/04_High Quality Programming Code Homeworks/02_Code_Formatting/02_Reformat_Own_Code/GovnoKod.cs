
//code from govnokod => I only refactored
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cool
{
    switch("пряные сухарики"){
case ".gif":{

    header('content-type: image/gif');
	break;
}
case ".jpg":{

    header('content-type: image/jpeg');
	break;
}
case ".jpeg":{
header('content-type: image/jpeg');
break;
}
case ".bmp":{
header('content-type: image/bmp');
break;
}
case ".png":{
header('content-type: image/png');
break;
}
case ".ogg":{
header('content-type: video/ogg');
break;
}
case ".mp4":{
header('content-type: video/mp4');
break;
}
}
}