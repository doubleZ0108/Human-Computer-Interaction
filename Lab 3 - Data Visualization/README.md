# Lab 3: Data Visualization

Make use of dash to visualize one of the three dataset.

Table of Contents
=================

   * [Lab 3: Data Visualization](#lab-3-data-visualization)
      * [Background](#background)
            * [<strong>What is Data Visualization?</strong>](#what-is-data-visualization)
            * [<strong>Tasks in Data Visualization</strong>](#tasks-in-data-visualization)
      * [Function](#function)
      * [Development Environment](#development-environment)
      * [Project Structure](#project-structure)
      * [How to Run](#how-to-run)
      * [ScreenShot](#screenshot)
            * [Interface(Size &amp; Content rating)](#interfacesize--content-rating)
            * [Interface(Price &amp; Rating)](#interfaceprice--rating)
            * [Switch from different Rating](#switch-from-different-rating)
            * [Switch from Free or Paid](#switch-from-free-or-paid)
            * [Switch from different item in the category](#switch-from-different-item-in-the-category)
            * [Rating](#rating)
      * [Function Realization](#function-realization)
         * [Dash Core Components](#dash-core-components)
            * [dcc.Dropdown](#dccdropdown)
            * [dcc.RadioItems](#dccradioitems)
            * [dcc.Tab](#dcctab)
            * [dcc.Graph](#dccgraph)
         * [Dash DAQ Components](#dash-daq-components)
            * [daq.Knob](#daqknob)
         * [Callbacks](#callbacks)
         * [Settle .CSV File](#settle-csv-file)
            * [Read file](#read-file)
            * [Filter](#filter)
            * [Get Data](#get-data)
      * [About the author](#about-the-author)
      
      

## Background

#### **What is Data Visualization?**

>  Data visualization is primarily designed to communicate and communicate information clearly and effectively through graphical means. 
>
> In order to effectively convey the concept of ideas, aesthetic forms and functions need to go hand in hand to achieve insight into fairly sparse and complex data sets by visually communicating key aspects and features.

**The basic idea of Data Visualization technology?**

>  To represent each data item in the database as a single primitive element. A large number of data sets constitute a data image, and each attribute value of the data is represented in the form of multidimensional data, which can be observed from different dimensions. Data to allow for more in-depth observation and analysis of the data.

#### **Tasks in Data Visualization**

| ***Task Categories***         | ***Task Types***                                             |
| ----------------------------- | ------------------------------------------------------------ |
| *Data and view specification* | **Visualize** data by choosing visual encodings<br />**Filter** out data to focus on relevant items<br />**Sort** items to expose patterns<br />**Derive** values of models from source data |
| *View manipulation*           | **Select** items to highlight, filter, or manipulate<br />**Navigate** to examine high-level patterns and low level detail<br />**Coordinate** views for linked exploration<br />**Organize** multiple windows and workspaces |
| *Process and provenance*      | **Record** analysis histories for revisitation, review, and sharing<br />**Annotate** patterns to document findings<br />**Share** views and annotations to enable<br/>collaboration<br />**Guide** users through analysis tasks or stories |



## Function

1. Choose a certain **catagory**.
2. To see only the **Free** Apps or **Paid** Apps or **All** Apps.
3. Change the **tag** to see other graph and content.
4. Change the **Rating** dial to see the Apps which hold the rating below this rate.
5. Overview the relation between **Reviews** and **Installs.**
6. Overview the relation between **Size** of the App and Total **Number** of the Apps in this range of size.
7. Overview the number in different **Content Rating**.
8. Overview the relation between **Price** of the App and Total **Number** of the Apps which the price is below this price.



## Development Environment

- **Development Environment:** Win 10

- **Development Software:**
  1. **PyCharm** *2019.1.1.PC-191.6605.12*
  2. **Visual Studio Code** 1.33.1.0
  
- **Development Language:**
  
  ​	python3
  
- **Mainly Reference Count:**
  
  1. dash(dash_core_components, dash_html_components, dash_daq)
  2. dash.dependencies (Input, Output, State)
  3. pandas
  4. plotly(plotly.graph_objs)
  5. csv
  
- **Others:**

  Use some **third-party CSS library** : https://codepen.io/chriddyp/pen/bWLwgP.css

  

## Project Structure

│  README.md
│  report.md
│  report.pdf
│  
├─dataset
│  └─google-play-store-apps
│          googleplaystore.csv
│          information.md
│          
└─src
        app.py
        Reader.py



## How to Run

1. File configuration:

   - ❗❗❗ Please **replace the dataset** -> googleplaystore.csv
   - Please create two python files under src folder:
     - **app.py** which contain the body of the dash and it hold the function to run the server
     - **Reader.py** which is used to copy with the .csv file
   - Final the folder structure will be as above.

2. Start the server by running app.py

   ``` 
   python app.py
   ```

3. Once the server starts up, access [http://localhost:8050](http://localhost:8050/) to get the UI.

4. Choose the item from the **Dropdown**, and you will see the graph which hold the data which come from this item only.

5. Click the **RadioItems**, *Free* to see the Apps which are free only, *Paid* to see the Apps which are cost only, *All* to see all the Apps.

6. Change the tags from the `Size & Content Rating` and `Price & Rating`

7. Slide the **Rating Knob(Dial)** to see the Apps which hold the rating below the rate you choose and you can see the current rate behind the ⭐

8. You can return to the last step by click the **undo** in the left-bottom of the page and **redo** to transfer to the next step.

9. You can Download plot as a png, Zoom, Pan, Box Select, Lasso Select, Zoom in, Zoom out, Auto scale Reset axes, Toggle Spike Lines, Show closest data on hover, Compare data on hover, which are powered by the DASH.



## ScreenShot

#### Interface(Size & Content rating)
![image.png](https://upload-images.jianshu.io/upload_images/12014150-1a3ea009fa5e85ba.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

![image.png](https://upload-images.jianshu.io/upload_images/12014150-8dde4e5e289d9006.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)

#### Interface(Price & Rating)

![image.png](https://upload-images.jianshu.io/upload_images/12014150-a3ced1ae61800a09.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)



#### Switch from different Rating

![切换评分.gif](https://upload-images.jianshu.io/upload_images/12014150-49240d20879c3a5b.gif?imageMogr2/auto-orient/strip)

#### Switch from Free or Paid

![切换付费or免费.gif](https://upload-images.jianshu.io/upload_images/12014150-512bc0ff283d4de3.gif?imageMogr2/auto-orient/strip)

#### Switch from different item in the category

![切换分类.gif](https://upload-images.jianshu.io/upload_images/12014150-7c275bc9ceff7d93.gif?imageMogr2/auto-orient/strip)



#### Rating

![12014150-556c69c07abdea2b.png](https://upload-images.jianshu.io/upload_images/12014150-dbbdb30894507e01.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240)



## Function Realization

### 	Dash Core Components

#### 		dcc.Dropdown

​	The dropdown is used for the user to choose the item from the category, and then you can see the data of the dataset which the category only belong to the item the user choose.

​	Whenever you change your choice, all the graph will change with the callback functions.

```python
# category下拉框
dcc.Dropdown(
    id='category',
    options=[{
        'label': i,
        'value': i
    } for i in available_indicators],  # 下拉框的项为软件分类列表
    value='ART_AND_DESIGN'),
```

#### 		dcc.RadioItems

​	The radioitems hold 3 different choices. Free to see free Apps only, paid to see cost Apps only, all to se all the Apps. 

​	Whenever you change your choice, all the graph will change with the callback functions.

```python
# Price单选按钮
dcc.RadioItems(
    id='price',
    options=[{
        'label': i,
        'value': i
    } for i in ['Free', 'Paid', 'All']],  # 单选按钮的项为 免费/付费/全部
    value='All',
    labelStyle={'display': 'inline-block'})

```

#### 		dcc.Tab

​	The Tab component allow the user to change between two tag, one is the Size & Content Rating, which you can see the Size Scatter(Bar) Graph and the Content Rating Pie Graph, another is the Price & Rating, which you can see the Price Scatter Graph and the Rating Knob.

The CSS of the Tab:

```css
# tab标签的css
tabs_styles = {'height': '44px'}
tab_style = {
    'borderBottom': '1px solid #d6d6d6',
    'padding': '6px',
    'fontWeight': 'bold'
}
tab_selected_style = {
    'borderTop': '1px solid #d6d6d6',
    'borderBottom': '1px solid #d6d6d6',
    'backgroundColor': '#119DFF',
    'color': 'white',
    'padding': '6px'
}
```



```python
dcc.Tabs(
    id="tabs",
    children=[
    # tab1 => 软件大小 & 应用分级
    dcc.Tab(label='Size & Content Rating',
            style=tab_style,
            selected_style=tab_selected_style,
            children=[
                html.Div([
                        # 软件大小折线图
                        dcc.Graph(id='size-graph',
                                    animate=True),
                        # 应用分级饼状图
                        dcc.Graph(
                            id='content-rating-graph',
                            animate=True)
                    ],
                    style={
                        'display': 'inline-block',
                        'width': '97%',
                        'height': '20%',
                        'padding': '0 0 0 0'
                    })
            ]),
    # tab2 => 软件价格 & 评分
    dcc.Tab(
        label='Price & Rating',
        style=tab_style,
        selected_style=tab_selected_style,
        children=[
            html.Div([
                    # 软件大小折线图
                    dcc.Graph(id='price-graph',
                                animate=True),
                ],
                style={
                    'display': 'inline-block',
                    'width': '90%',
                    'height': '20%',
                    'padding': '0 0 0 0'
                })
        ]),
],
style=tabs_styles),
```

#### 		dcc.Graph

​	I draw 4 graphs:

  1. Main-Scatter graph, the model is markers

     ```python
     'data': [
         go.Scatter(
             x=Reviews,      # x轴为评论数
             y=Installs,     # y轴为安装数
             text=App,       # 点信息为App的名字
             mode='markers',
             marker={
                 'size': 15,
                 'opacity': 0.5,
                 'line': {
                     'width': 0.5,
                     'color': 'white'
                     }
     })],
     ```

  2. Size-Bar(Scatter) graph

     ```python
     'data': [{
         'x': size_category,     # x轴为软件大小分类
         'y': size_list,         # y轴为软件大小列表
         'type': 'Scatter',
     }],
     ```

  3. Content-Rating-Pie graph

     ```python
      trace = go.Pie(
         labels=content_rating_category,     # x轴为应用分级分类
         values=content_rating_list,         # y轴为应用分级列表
     )
     'data': [trace],
     ```

  4. Price-Scatter graph

     ```python
     'data': [{
         "x": price_category,        # x轴为软件价格分类
         "y": price_list,            # y轴为软件价格列表
         "mode": "lines+markers",
         'type': 'Scatter',
         'name': 'Line'
     }],
     ```

     

### 	Dash DAQ Components

#### 		daq.Knob

​	The knob present as a dial which allow the user to change from 0~5. Once the user choose a mark, all the graphs will change according to the mark.

​	The data in the graph will hold the rating which are below to the mark the user choose.

```python
# 评分仪表盘
daq.Knob(id='my-knob',
            label="Rating",
            labelPosition='bottom',
            value=5,
            max=5,
            scale={
                'start': 0,
                'labelInterval': 1,
                'interval': 1
            }),
# 仪表盘的callback显示
html.Div(id='knob-output',
            style={
                'marginTop': -80,
                'marginLeft': 425
            }),
# star图标
html.Img(
    id='star-img',
    src=
    'https://upload-images.jianshu.io/upload_images/12014150-c2ee9fe0591b3247.png?imageMogr2/auto-orient/strip%7CimageView2/2/w/1240',
    height='50px',
    width='50px',
    style={
        'marginTop': -120,
        'marginLeft': 375
    })
```



### 	Callbacks

```python
# main点状图 callback
@app.callback(
    dash.dependencies.Output('main-graph', 'figure'),   # 输出 -> main点状图
    [
        dash.dependencies.Input('category', 'value'),   # 输入1 -> 软件分类
        dash.dependencies.Input('price', 'value'),      # 输入2 -> 软件是否收费
        dash.dependencies.Input('my-knob', 'value')     # 输入3 -> 评分仪表盘
    ])  # 输入2 -> 价格

# size折线图 callback
@app.callback(
    dash.dependencies.Output('size-graph', 'figure'),   # 输出 -> size折线图
    [
        dash.dependencies.Input('category', 'value'),   # 输入1 -> 软件分类
        dash.dependencies.Input('price', 'value')       # 输入2 -> 软件是否收费
    ])

# content rating饼状图 callback
@app.callback(
    dash.dependencies.Output('content-rating-graph', 'figure'),     # 输出 -> content rating饼状图
    [
        dash.dependencies.Input('category', 'value'),               # 输入1 -> 软件分类
        dash.dependencies.Input('price', 'value')                   # 输入2 -> 软件是否收费
    ])

# price折线图 callback
@app.callback(
    dash.dependencies.Output('price-graph', 'figure'),  # 输出 -> price折线图
    [
        dash.dependencies.Input('category', 'value'),   # 输入1 -> 软件分类
        dash.dependencies.Input('price', 'value'),      # 输入2 -> 软件是否收费
        dash.dependencies.Input('my-knob', 'value')     # 输入3 -> 评分仪表盘
    ])

# 评分仪表盘 callback
@app.callback(
    dash.dependencies.Output('knob-output', 'children'), # 输出 -> 仪表盘文字
    [dash.dependencies.Input('my-knob', 'value')])       # 输入 -> 评分仪表盘
```



### 	Settle .CSV File

#### 		Read file

​	Two ways to read the .csv file:

	1. Use the csv.reader in the **csv package**
 	2. Use the pd.read_cav in the **pandas package**

```python
# 读取csv文件
def read_file():
    file = csv.reader(
        open('dataset\google-play-store-apps\googleplaystore.csv',
             encoding='utf-8'))

    return file

# pd方式读取csv文件
df = pd.read_csv('dataset\google-play-store-apps\googleplaystore.csv')
# 获取软件分类列表
available_indicators = df['Category'].unique()
```

#### 		Filter

```python
# 按照分类名和是否付费进行筛选
def file_filter(file, category_name, price_choice):
    newfile = []
    for row in file:
        if row[1] == category_name:
            if price_choice == 'All':
                newfile.append(row)
            elif price_choice == 'Free' and row[7] == '0':
                newfile.append(row)
            elif price_choice == 'Paid' and row[7] != '0':
                newfile.append(row)

    return newfile

# 按照评分进行删选
def rating_filter(file, rating_value):
    newfile = []
    for row in file:
        if row[2]=='Rating':
            continue
        elif row[2]=='NaN':
            newfile.append(row)
        else:
            value = float(row[2])
            if value < rating_value:
                newfile.append(row)

    return newfile
```

#### 		Get Data

```python
# 获取main散点图所需数据
def get_main(file):
    Reviews = []        # 评论数
    Installs = []       # 下载数
    App = []            # App的名称
    ...
    
# 获取size折线图所需数据
def get_size(file):
    size_category = [
        '0~300K', '300K~600K', '600K~900K', '900K~25M', '25M~50M',
        '50M~75M','75M~100M', 'Varies with device'
    ]
    size_list = [0] * len(size_category)
    ...
    
# 获取content rating饼状图所需数据
def get_content_rating(file):
    content_rating_category = [
        'Everyone', 'Teen', 'Everyone 10+', 
        'Mature 17+', 'Adults only 18+','Unrated'
    ]
    content_rating_list = [0] * len(content_rating_category)
    ...
  
# 获取price折线图所需数据
def get_price(file):
    price_category = [
        '0','$1~$50','$50~$100','$100~$150','$150~$200',
        '$200~$250','$250~$300','$300~$350','$350~$400'
    ]
    price_list = [0] * (len(price_category))
    ...
```



## About the author

​	**ID**			1754060

​	**name**	  Zhe Zhang

​	**adviser**	Ying Shen

​	**contact**	email: doubleZ0108@gmail.com
