console.log('Reading Event');
var AWS = require('aws-sdk');
var dynamodb = new AWS.DynamoDB();
const docClient = new AWS.DynamoDB.DocumentClient({region: 'us-west-2'});

exports.handler = function(event, context, callback) {
    var tableName = "ColdCutsDB";
    var params = {
        TableName: tableName,
        KeyConditionExpression: "Class_ID = :class",
        ExpressionAttributeValues: {
        ":class": event.params.querystring.Class_ID
    }
    }
    
    docClient.query(params, function(err, data){
        if(err){
            callback(err,null);
        } else{
            callback(null,data);
            data.Items.forEach(function(item){
                console.log(" -", item.Class_ID + ": " + item.Student_Name);
        });
    };
});
}