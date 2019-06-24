import dash
import dash_core_components as dcc
import dash_html_components as html
import dash_daq as daq
from dash.dependencies import Input, Output, State

import pandas as pd
import numpy as np
import plotly.graph_objs as go

from Reader import *

external_stylesheets = ['https://codepen.io/chriddyp/pen/bWLwgP.css']

app = dash.Dash(__name__, external_stylesheets=external_stylesheets)

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

# pd方式读取csv文件
df = pd.read_csv('dataset\google-play-store-apps\googleplaystore.csv')
# 获取软件分类列表
available_indicators = df['Category'].unique()

# csv.reader方式读取csv文件
file = read_file()


app.layout = html.Div([
    html.Div([
            html.Div([
                    # category下拉框
                    dcc.Dropdown(id='category',
                                 options=[{
                                     'label': i,
                                     'value': i
                                 } for i in available_indicators],  # 下拉框的项为软件分类列表
                                 value='ART_AND_DESIGN'),
                    # Price单选按钮
                    dcc.RadioItems(id='price',
                                   options=[{
                                       'label': i,
                                       'value': i
                                   } for i in ['Free', 'Paid', 'All']], # 单选按钮的项为 免费/付费/全部
                                   value='All',
                                   labelStyle={'display': 'inline-block'})
                ],
                style={
                    'width': '49%',
                    'display': 'inline-block'
                }),

            # tab -> 可以切换两个视图
            html.Div([
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
                ],
                style={
                    'width': '49%',
                    'float': 'right',
                    'display': 'inline-block'
                })
        ],
        style={
            'borderBottom': 'thin lightgrey solid',
            'backgroundColor': 'rgb(250, 250, 250)',
            'padding': '10px 5px'
        }),
    
    html.Div([
            # main点状图
            dcc.Graph(id='main-graph', 
            animate=True
        )],
            style={
                'width': '49%',
                'display': 'inline-block',
                'padding': '0 20'
            }),
])



# main点状图 callback
@app.callback(
    dash.dependencies.Output('main-graph', 'figure'),   # 输出 -> main点状图
    [
        dash.dependencies.Input('category', 'value'),   # 输入1 -> 软件分类
        dash.dependencies.Input('price', 'value'),      # 输入2 -> 软件是否收费
        dash.dependencies.Input('my-knob', 'value')     # 输入3 -> 评分仪表盘
    ])  # 输入2 -> 价格
def update_maingraph(category_name, price_choice, rating_value):

    # 获取评论数, 下载量, 软件名称
    newfile = read_file()
    newfile = file_filter(newfile, category_name, price_choice)
    newfile = rating_filter(newfile, rating_value)

    [Reviews, Installs, App] = get_main(newfile)
    # print(Reviews, Installs, App)

    return {
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
        'layout':
            go.Layout(
                xaxis={
                    'title': 'Reviews',
                    },
                yaxis={
                    'title': 'Installs',
                    },
                margin={
                    'l': 40,
                    'b': 30,
                    't': 10,
                    'r': 0
                    },
                height=450,
                hovermode='closest')
        }


# size折线图 callback
@app.callback(
    dash.dependencies.Output('size-graph', 'figure'),   # 输出 -> size折线图
    [
        dash.dependencies.Input('category', 'value'),   # 输入1 -> 软件分类
        dash.dependencies.Input('price', 'value')       # 输入2 -> 软件是否收费
    ])
def update_sizeGraph(category_name, price_choice):

    # 获取软件大小分类, 软件大小列表
    newfile = read_file()
    newfile = file_filter(newfile, category_name, price_choice)

    [size_category, size_list] = get_size(newfile)
    # print(size_category, size_list)

    return {
        'data': [{
            'x': size_category,     # x轴为软件大小分类
            'y': size_list,         # y轴为软件大小列表
            'type': 'Scatter',
            }],
        'layout':
            go.Layout(
                margin={
                    'l': 40,
                    'b': 50,
                    't': 20,
                    'r': 20
                    },
                legend={
                    'x': 0,
                    'y': 1
                    },
                height=280,
                hovermode='closest')
        }


# content rating饼状图 callback
@app.callback(
    dash.dependencies.Output('content-rating-graph', 'figure'),     # 输出 -> content rating饼状图
    [
        dash.dependencies.Input('category', 'value'),               # 输入1 -> 软件分类
        dash.dependencies.Input('price', 'value')                   # 输入2 -> 软件是否收费
    ])
def update_conten_tratingGraph(category_name, price_choice):

    # 获取应用分级分类, 应用分级列表
    newfile = read_file()
    newfile = file_filter(newfile, category_name, price_choice)

    [content_rating_category, content_rating_list] = get_content_rating(newfile)
    print(content_rating_category,content_rating_list)


    trace = go.Pie(
        labels=content_rating_category,     # x轴为应用分级分类
        values=content_rating_list,         # y轴为应用分级列表
        )
    return {
        'data': [trace],
        'layout':
            go.Layout(
                margin={
                    'l': 130,
                    'b': 30,
                    't': 50,
                    'r': 0
                    },
                height=300,
                hovermode='closest')
        }


# price折线图 callback
@app.callback(
    dash.dependencies.Output('price-graph', 'figure'),  # 输出 -> price折线图
    [
        dash.dependencies.Input('category', 'value'),   # 输入1 -> 软件分类
        dash.dependencies.Input('price', 'value'),      # 输入2 -> 软件是否收费
        dash.dependencies.Input('my-knob', 'value')     # 输入3 -> 评分仪表盘
    ])
def update_priceGraph(category_name, price_choice, rating_value):

    # 获取软件价格分类, 软件价格列表
    newfile = read_file()
    newfile = file_filter(newfile, category_name, price_choice)
    newfile = rating_filter(newfile, rating_value)

    [price_category, price_list] = get_price(newfile)

    return {
        'data': [{
            "x": price_category,        # x轴为软件价格分类
            "y": price_list,            # y轴为软件价格列表
            "mode": "lines+markers",
            'type': 'Scatter',
            'name': 'Line'
            }],
        'layout':
            go.Layout(
                margin={
                    'l': 130,
                    'b': 50,
                    't': 50,
                    'r': 40
                    },
                height=300,
                hovermode='closest')
        }


# 评分仪表盘 callback
@app.callback(
    dash.dependencies.Output('knob-output', 'children'), # 输出 -> 仪表盘文字
    [dash.dependencies.Input('my-knob', 'value')])       # 输入 -> 评分仪表盘
def update_output(value):
    return '<= {}'.format(value)




if __name__ == '__main__':
    app.run_server(debug=True, host='localhost')