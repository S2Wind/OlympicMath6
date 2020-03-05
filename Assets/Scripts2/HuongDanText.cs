using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HuongDanText : MonoBehaviour
{
    TextMeshProUGUI texx;
    void Start()
    {
        texx = GetComponent<TextMeshProUGUI>();
        texx.text =
        "Mỗi lượt chơi có 1 bức ảnh bí ẩn bị che bởi 9 ô , bạn chọn 1 trong 9 ô để trả lời câu hỏi trong 20 phút : \nTrả lời đúng thì ô sẽ bị xóa \nTrả lời sai thì ô đó sẽ không trả lời được nữa \n " +
        "Càng mở được nhiều ô thì càng được nhiều điểm\n Thách đấu với các bạn số điểm của bạn nào??!";
    }

   
}
