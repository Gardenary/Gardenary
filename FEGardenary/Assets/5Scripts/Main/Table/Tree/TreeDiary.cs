using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net.Http;
using System;
using System.Net;
using Newtonsoft.Json;
using System.Text;

public class TreeDiary : MonoBehaviour
{
    //�츮 ���� uri�� ����� ��ū(���Ƿ� ���� ��ū)
    private string uri = "https://k7a604.p.ssafy.io/api/";
    private string token = "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiIxMjMxIiwiaWF0IjoxNjY3Nzk5NzQzLCJleHAiOjE2Njc4MTc3NDN9.whQJ5SPEkAL0QBwecY7b9pICUSMQj1vkA04E6PVconA";
    public ResTreeDiary TreeDiaryList;
    public int test = 1;

    // Start is called before the first frame update
    void Start()
    {
        //���� ���̾ ��ȸ API
        //��û�� ������ ���� client
        var client = new HttpClient();

        //body�� ���� ������
        var dateCreate = new ReqTreeDiary
        {
            date = "2022-11-08T09:54:01.242012"
        };
        var treeDate = JsonConvert.SerializeObject(dateCreate);
        var requestTreeDate = new StringContent(treeDate, Encoding.UTF8, "application/json");

        //Method�� Uri�� �����ϰ� Header�� ��ū�� �ִ´�
        var httpRequestMessage = new HttpRequestMessage
        {
            Method = HttpMethod.Post,
            RequestUri = new Uri(uri + "tree/diary/date"),
            Headers =
            {
                { HttpRequestHeader.Authorization.ToString(), "Bearer " + token }
            },
        };

        //���� body�� ���� �����͸� ���� ����ش�
        httpRequestMessage.Content = requestTreeDate;
       
        //API ��û�� �����ϰ� json���� ����� �޾ƿ´�
        var response = client.SendAsync(httpRequestMessage).Result;
        var json = response.Content.ReadAsStringAsync().Result;
        //json���� �޾ƿ� ����� string���� �ٲ۴�(?)
        //�����͸� ���� Ŭ������ �ϳ� ������ �Ѵ�
        TreeDiaryList = JsonConvert.DeserializeObject<ResTreeDiary>(json);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
