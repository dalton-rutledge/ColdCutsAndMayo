var AWS = require('aws-sdk');
var dynamodb = new AWS.DynamoDB();
const docClient = new AWS.DynamoDB.DocumentClient({region: 'us-west-2'});

exports.handler = function(event, context, callback) {
    //if (event.body !== null && event.body !== undefined) {
      //  var body = JSON.parse(event.body)
    //}
    //console.log(body);
    //console.log(JSON.stringify(event));
    var table = "ColdCutsDB";
    //var wrongSet = new Set(event.Wrong_Probs)
    //console.log(wrongSet)
    //console.log(event.wrongProbs)
    var params = {
    TableName:table,
    Key:{
        "Class_ID": event.params.querystring.Class_ID,
        "Student_Name": event.params.querystring.Student_Name
    },
    UpdateExpression: "ADD #k1 :tp, #k2 :lw, #k3 :ll SET #k4 = list_append(#k4,:wp)" ,
    ExpressionAttributeNames: {
        '#k1': 'Time_Played',
        '#k2': 'Level_Wins',
        '#k3': 'Level_Losses',
        '#k4': 'Wrong_Probs'
    },
    ExpressionAttributeValues:{
        ":tp": parseInt(event.body.Time_Played, 10),
        ":lw": parseInt(event.body.Level_Wins, 10), 
        ":ll": parseInt(event.body.Level_Losses, 10),
        ":wp": event.body.Wrong_Probs
    },
    ReturnValues:"ALL_NEW"
};
docClient.update(params, function(err, data) {
    if (err) {
        console.error("Unable to update item. Error JSON:", JSON.stringify(err, null, 2));
    } else {
        console.log("UpdateItem succeeded:", JSON.stringify(data, null, 2));
        callback(null,data);
    }
});

//     docClient.updateItem(params, function(err, data) {
//         if(err){
//             context.fail('ERROR: Dynamo failed:  ' + err);
//         } else {
//             console.log('Dynamo Success: ' + JSON.stringify(data, null, '   '));
//             context.succeed('SUCCESS');
//         }
//     });
//     callback(null, {
//         statusCode: '200'
//     })
// }
}
