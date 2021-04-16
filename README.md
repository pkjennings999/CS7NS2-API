# CS7NS2-API
This is the API for the CS7NS2 IoT Group Project. It allows for images to be sent from a device, runs those images through an object detection model, and finally sends the result of this back to the client.

## Requirements
dotnet 5 is required to run.

## Instructions
The API can be run in one of two ways. It can be done by loading into Visual Studio and clicking run, or it can be run by the command
```
dotnet run CS7NS2-API
```

## How it works
There are two endpoints provided. 
```
GET {DOMAIN}/api/Facemask
```
and
```
POST {DOMAIN}/api/Facemask
```
The GET request is provided as a way of seeing if the service is running without going through sending an image for evaluation. The POST request is what allows the client to send an image of a person, which is then parsed and sent to the local python model, found in the maskDetector folder. The model, which has a more detailed [README](maskDetector/README.md) explaining how it works, evaluates whether there is a person wearing a mask in the image or not. This result is then read and parsed by the API, and one of the following responses is sent back to the client:

- TRUE, if there is a person wearing a mask
- FALSE, if there is a person not wearing a mask properly
- Image not found, if there was no image found by the API
- Face not found, if no face was found in the image
- Unexpected script response, if something unexpected went wrong with the python script

## Updates
One key feature of this API is the inclusion of continuous integration/continuous deployment (CI/CD). This is achieved by using GitHub actions and the [yaml pipeline file](.github/workflows/main_facemaskcheck.yml) that has been written. When something is pushed to the main branch of the repo, the API and the python script are built, packed into an artefact, and deployed to the cloud.