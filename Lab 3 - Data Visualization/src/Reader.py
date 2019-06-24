import pandas as pd
import plotly.graph_objs as go
import csv

# 读取csv文件
def read_file():
    file = csv.reader(
        open('dataset\google-play-store-apps\googleplaystore.csv',
             encoding='utf-8'))

    return file

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


# 获取main散点图所需数据
def get_main(file):
    Reviews = []        # 评论数
    Installs = []       # 下载数
    App = []            # App的名称

    for row in file:
        if row[0]!='App':
            App.append(row[0])
        
        if row[3]!='Reviews':
            Reviews.append(row[3])
        
        if row[5]!='Installs':
            Installs.append(row[5])
    
    return[Reviews, Installs, App]
# 获取size折线图所需数据
def get_size(file):
    size_category = [
        '0~300K', '300K~600K', '600K~900K', '900K~25M', '25M~50M',
        '50M~75M','75M~100M', 'Varies with device'
    ]
    size_list = [0] * len(size_category)
    variesNum = 0

    for row in file:
        if row[4][-1] == 'M':
            num = float(row[4][0:-1])
            size_list[int(num // 25) + 3] += 1
        elif row[4][-1] == 'k':
            num = float(row[4][0:-1])
            if num > 900:
                size_list[3] += 1
            else:
                size_list[int(num // 300)] += 1
        elif row[4] == 'Varies with device':
            size_list[-1] += 1
        else:
            continue  # 去掉第一行的Size

    return [size_category, size_list]
# 获取content rating饼状图所需数据
def get_content_rating(file):
    content_rating_category = [
        'Everyone', 'Teen', 'Everyone 10+', 
        'Mature 17+', 'Adults only 18+','Unrated'
    ]
    content_rating_list = [0] * len(content_rating_category)

    for row in file:
        content_rating_list[content_rating_category.index(row[8])] += 1

    return [content_rating_category, content_rating_list]
# 获取price折线图所需数据
def get_price(file):
    price_category = [
        '0','$1~$50','$50~$100','$100~$150','$150~$200',
        '$200~$250','$250~$300','$300~$350','$350~$400'
    ]
    price_list = [0] * (len(price_category))

    for row in file:
        if row[7] == 'Price':
            continue
        elif row[7] == '0':
            price_list[0] += 1
        else:
            price = int(float(row[7][1:])/50)
            price_list[price] += 1
    
    return [price_category,price_list]


if __name__ == '__main__':
    file = read_file()
    [Reviews, Installs, App] = get_main(file)
    [size_category,size_list] = get_size(file)
    [content_rating_category, content_rating_list] = get_content_rating(file)
    [price_category, price_list] = get_price(file)


    for i in range(len(size_category)):
        print('Size: {} {}'.format(size_category[i],size_list[i]))
    for i in range(len(content_rating_category)):
        print('Content Rating: {} {}'.format(content_rating_category[i],content_rating_list[i]))
    for i in range(len(price_category)):
        print('Price: {} {}'.format(price_category[i], price_list[i]))