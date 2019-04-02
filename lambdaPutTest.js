exports.handler = async (event) => {
    // TODO implement
    var strings = event.params.querystring.Test_ID;
    const response = {
        statusCode: 200,
        body: JSON.stringify(strings),
    };
    return response;
};


