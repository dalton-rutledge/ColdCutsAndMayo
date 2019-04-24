console.log('Reading Event');
var AWS = require('aws-sdk');
const docClient = new AWS.DynamoDB.DocumentClient({region: 'us-west-2'});

exports.handler = function(event, context, callback) {
    var tableName = "teacherProblems";
    var params = {
        TableName: tableName,
        KeyConditionExpression: "Class_ID = :class",
        ExpressionAttributeValues: {
        ":class": event.params.querystring.Class_ID
    }
    };
    
    docClient.query(params, function(err, data){
        if(err){
            callback(err,null);
        } else{
            var problems = data.Items[0]["Problems"];
            var answers =  data.Items[0]["Answers"];
            callback(null, problems + ',' + answers)
    }
});
};
