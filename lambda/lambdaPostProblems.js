console.log('Loading Event');
var AWS = require('aws-sdk');
var dynamodb = new AWS.DynamoDB();

exports.handler = function(event, context, callback) {
    //console.log("Request recieved:\n", JSON.stringify(event));
    //console.log("Context.recieved:\n", JSON.stringify(context));
    //const body = JSON.parse(event.body);
    //console.log(event)
    var problems = event.Problems[0].concat(','.concat(event.Problems[1].concat(','.concat(event.Problems[2].concat(','.concat(event.Problems[3].concat(','.concat(event.Problems[4]))))))))
    var answers = event.Answers[0].concat(','.concat(event.Answers[1].concat(','.concat(event.Answers[2].concat(','.concat(event.Answers[3].concat(','.concat(event.Answers[4]))))))))
    console.log(event.Problems);
    var tableName = "teacherProblems";
    dynamodb.putItem({
        "TableName" : tableName,
        "Item": {
            "Class_ID": {
                "S": event.Class_ID
            },
            "Problems": {
                "S": problems
        },
            "Answers": {
                "S": answers
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
        statusCode: '200' + ", Class_ID: " + event.Class_ID + ",  Problems: " + problems + ",  Answers: " + answers
    })
}
