### Detect:

```
python detect.py --source 0 --weights mask_detector/weights/best.pt --iou-thres 0.3 --conf-thres 0.5
```

### Creating venv:

```
python -m venv venv
./venv/Scripts/activate
pip install -r requirements.txt -f https://download.pytorch.org/whl/torch_stable.html
```
