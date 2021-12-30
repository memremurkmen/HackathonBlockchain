const express = require('express');
const app = express();
const bodyParser = require('body-parser');
app.use(bodyParser.urlencoded({ extended: false }))

app.get('/', function (req, res) {
  res.sendFile(__dirname + '/index.html');
});

app.listen(3222, function () {
  console.log('Sunucu localhost:3222 da başlatıldı...');
});

var transaction = "";

 app.post('/getIslem', (req,res) => {
   transaction += req.body.islem;
   console.log(transaction)
   res.status(200).send("success");
})

app.get('/getTransaction', (req,res) => {
  console.log("calisti")
  console.log(transaction)
  res.send(transaction);
})




 