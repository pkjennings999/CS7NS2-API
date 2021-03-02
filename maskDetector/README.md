### Detect:

```
python detect.py --source 0 --weights mask_detector/weights/best.pt --iou-thres 0.3 --conf-thres 0.5
```

### Creating venv:

```
python -m venv venv
pip install opencv-python
pip install torch
pip install requests
pip install pillow
pip install tqdm
pip install six
pip install yaml
pip install pyyaml
pip install matplotlib
pip install pandas
pip install seaborn
pip install pycocotools
pip install thop
pip install tensorboard
pip install torch==1.7.0+cu110 torchvision==0.8.1+cu110 torchaudio===0.7.0 -f https://download.pytorch.org/whl/torch_stable.html
```
