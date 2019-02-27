console.log('Loading Event');
var AWS = require('aws-sdk');
var dynamodb = new AWS.DynamoDB();

exports.handler = function(event, context, callback) {
    //console.log("Request recieved:\n", JSON.stringify(event));
    //console.log("Context.recieved:\n", JSON.stringify(context));
    //const body = JSON.parse(event.body);
    //console.log(event)
    var tableName = "ColdCutsDB";
    dynamodb.putItem({
        "TableName" : tableName,
        "Item": {
            "Class_ID": {
                "S": event.Class_ID
            },
            "Student_Name": {
                "S": event.Student_Name
            },
            "Grade": {
                "N": event.Grade
            },
            "Time Played": {
            "N": event.TimePlayed
            }
            }
    }, function(err, data) {
        if(err){
            context.fail('ERROR: Dynamo failed:  ' + err);
        } else {
            console.log('Dynamo Success: ' + JSON.stringify(data, null, '   '));
            context.succeed('SUCCESS');
        }
    });
    callback(null, {
        statusCode: '200' + ", Class_ID: " + event.Class_ID + ",  Student_Name: " + event.Student_Name
    })
}
