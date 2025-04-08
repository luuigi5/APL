import json

def FromStringToJson(request):
    requestJson = json.dumps(request)
    return requestJson

def FromJsonToString(response):
    responseJson = json.loads(response.decode())
    return responseJson
